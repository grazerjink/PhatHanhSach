using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Service.Services;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("bao-cao/nxb")]
    public class ThanhToanController : Controller
    {
        IThanhToanService thanhToanService;
        ISachService sachService;
        INhaXuatBanService nxbService;
        ICtThanhToanService ctThanhToanService;
        ITinhTrangService tinhTrangService;
        ICongNoNXBService congNoNXBService;

        public ThanhToanController(
               IThanhToanService thanhToanService,
               ISachService sachService,
               INhaXuatBanService nxbService,
               ICtThanhToanService ctThanhToanService,
               ITinhTrangService tinhTrangService,
               ICongNoNXBService congNoNXBService)
        {
            this.thanhToanService = thanhToanService;
            this.sachService = sachService;
            this.nxbService = nxbService;
            this.ctThanhToanService = ctThanhToanService;
            this.tinhTrangService = tinhTrangService;
            this.congNoNXBService = congNoNXBService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult DanhSachBaoCao()
        {
            Session.RemoveAll();
            var dsBaoCaoNXB = thanhToanService.GetAll(new string[] { "NhaXuatBan", "TinhTrang" });
            var dsBaoCaoNXBViewModel = Mapper.Map<IEnumerable<ThanhToan>, IEnumerable<ThanhToanViewModel>>(dsBaoCaoNXB);
            return View(dsBaoCaoNXBViewModel);
        }

        [Route("tao-bao-cao")]
        [HttpGet]
        public ActionResult TaoBaoCao()
        {
            return View(new ThanhToanViewModel());
        }

        [Route("tao-bao-cao")]
        [HttpPost]
        public ActionResult TaoBaoCao(ThanhToanViewModel thanhToanVm, string TenNXB)
        {
            if (Request.Form["analyze"] != null)
            {
                if (ModelState.IsValid)
                {
                    var nxb = nxbService.GetSingleByName(TenNXB);
                    if (nxb == null)
                    {
                        ModelState.AddModelError("", "Thông tin nhà xuất bản không tồn tại.");
                    }
                    else
                    {
                        thanhToanVm.IdNXB = nxb.Id;

                        var listThongKe = thanhToanService.GetListAnalysisReport(thanhToanVm.IdNXB, thanhToanVm.NgayBatDau, thanhToanVm.NgayKetThuc);
                        if (listThongKe.Count == 0)
                        {
                            ModelState.AddModelError("", "Chưa nhập hàng từ nhà xuất bản này.");
                        }
                        else if (thanhToanService.CheckReportIsCreated(thanhToanVm.IdNXB, thanhToanVm.NgayBatDau))
                        {
                            ModelState.AddModelError("", "Khoảng thời gian đã được lập báo cáo rồi.");
                        }
                        else
                        {
                            // Clear at the second click
                            Session["ThanhToan"] = null;
                            // Add new value for session
                            thanhToanVm.NhaXuatBan = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(nxb);
                            thanhToanVm.dsThongKeNXB = listThongKe;
                            foreach (var ct in listThongKe)
                            {
                                thanhToanVm.TongTienConNo += ct.TongTienNo;
                                if(ct.TongTienXuat != null)
                                    thanhToanVm.TongTienSachBan += (double)ct.TongTienXuat;
                            }
                            Session["ThanhToan"] = thanhToanVm;
                        }
                    }
                }
            }
            else if (Request.Form["create"] != null)
            {
                var tt = (ThanhToanViewModel)Session["ThanhToan"];
                var newThanhToan = new ThanhToan();
                newThanhToan.UpdateThanhToan(tt);
                newThanhToan.TongTienConNo += tt.TienNoThangTruoc;
                newThanhToan.IdTinhTrang = CommonConstant.DA_BAO_CAO;
                newThanhToan.NgayXacNhan = newThanhToan.ThoiGianLapPhieu;
                thanhToanService.Add(newThanhToan);
                thanhToanService.Save();

                foreach (var ct in tt.dsThongKeNXB)
                {
                    var ctThanhToan = new CtThanhToan
                    {
                        IdSach = ct.Id,
                        IdThanhToan = newThanhToan.Id,
                        SoLuongNhap = ct.SoLuongNhap,
                        SoLuongTonDotTruoc = ct.SoLuongTonDotTruoc,
                        TongTienNhap = ct.TongTienNhap,
                        SoLuongXuat = ct.SoLuongXuat,
                        TongTienXuat = ct.TongTienXuat,
                        SoLuongCon = ct.SoLuongNhap + ct.SoLuongTonDotTruoc - ct.SoLuongXuat,
                        TienNo = ct.TongTienNo,
                        DonGiaNhap = ct.DonGiaNhap
                    };
                    ctThanhToanService.Add(ctThanhToan);
                }
                thanhToanService.Save();
                Session["ThanhToan"] = null;
                TempData["Success"] = "Đã thêm thành công một báo cáo NXB.";
                Session.RemoveAll();
                return Redirect("/bao-cao/nxb/");
            }
            return View(thanhToanVm);
        }

        [Route("chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult ChiTietBaoCao(int id)
        {
            var thanhToan = thanhToanService.GetById(id, new string[] { "NhaXuatBan", "TinhTrang" });
            var thanhToanVm = Mapper.Map<ThanhToan, ThanhToanViewModel>(thanhToan);

            var ctThanhToan = ctThanhToanService.GetMultiById(thanhToanVm.Id, new string[] { "Sach" });
            thanhToanVm.CtThanhToans = Mapper.Map<IEnumerable<CtThanhToan>, IEnumerable<CtThanhToanViewModel>>(ctThanhToan);

            Session["TinhTrangBanDau"] = thanhToanVm.IdTinhTrang;
            Session["TongTienSachBan"] = thanhToanVm.TongTienSachBan;
            Session["dsCtBaoCao"] = thanhToanVm.CtThanhToans;

            if (TempData["Changed"] != null)
            {
                ViewBag.Changed = TempData["Changed"];
            }
            else
            {
                ViewBag.Changed = false;
            }

            var dsTinhTrang = tinhTrangService.GetAll();
            ViewBag.dsTinhTrang = dsTinhTrang;

            return View(thanhToanVm);
        }

        [Route("cap-nhat-chi-tiet")]
        [HttpPost]
        public ActionResult CapNhatBaoCao(ThanhToanViewModel thanhToanVm)
        {
            if (ModelState.IsValid)
            {
                int tinhTrangBanDau = (int)Session["TinhTrangBanDau"];
                if (tinhTrangBanDau == CommonConstant.DA_THANH_TOAN)
                {
                    TempData["Error"] = "Không thể cập nhật khi báo cáo đã thanh toán.";
                }
                else if (tinhTrangBanDau == CommonConstant.DA_HUY)
                {
                    TempData["Error"] = "Không thể cập nhật khi báo cáo đã hủy.";
                }
                else
                {
                    if (thanhToanVm.TongTienThanhToan < (double)Session["TongTienSachBan"])
                    {
                        TempData["Error"] = "Yêu cầu trả đủ số tiền sách bán được.";
                    }
                    else
                    {
                        var updateThanhToan = thanhToanService.GetById(thanhToanVm.Id);
                        updateThanhToan.IdTinhTrang = thanhToanVm.IdTinhTrang;
                        updateThanhToan.NgayXacNhan = thanhToanVm.NgayXacNhan;
                        updateThanhToan.TongTienThanhToan = thanhToanVm.TongTienThanhToan;
                        thanhToanService.Update(updateThanhToan);
                        thanhToanService.Save();
                        Session.RemoveAll();
                        TempData["Success"] = "Cập nhật trạng thái thành công.";
                    }
                }
            }

            return RedirectToAction("ChiTietBaoCao", new { id = thanhToanVm.Id });
        }
    }
}