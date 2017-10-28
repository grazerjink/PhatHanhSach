using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Service.Services;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("bao-cao/nxb")]
    public class ThanhToanController : Controller
    {
        private IThanhToanService thanhToanService;
        private ISachService sachService;
        private INhaXuatBanService nxbService;
        private ICtThanhToanService ctThanhToanService;
        private ITinhTrangService tinhTrangService;
        private ICongNoNXBService congNoNXBService;

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
        public ActionResult TaoBaoCao(ThanhToanViewModel thanhToanVm)
        {
            if (Request.Form["analyze"] != null)
            {
                if (ModelState.IsValid)
                {
                    var listThongKe = thanhToanService.GetListAnalysisReport(thanhToanVm.IdNXB, thanhToanVm.NgayBatDau, thanhToanVm.NgayKetThuc);
                    if (listThongKe.Count > 0)
                    {
                        // Clear at the second click
                        Session["ThanhToan"] = null;

                        // Add new value for session
                        thanhToanVm.dsThongKeNXB = listThongKe;
                        Session["ThanhToan"] = thanhToanVm;
                    }
                    else
                        ModelState.AddModelError("", "Chưa nhập hàng từ nhà xuất bản này.");
                }
            }
            else if (Request.Form["create"] != null)
            {
                if (ModelState.IsValid)
                {
                    var tt = (ThanhToanViewModel)Session["ThanhToan"];
                    var newThanhToan = new ThanhToan();
                    newThanhToan.UpdateThanhToan(tt);
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
                            SoLuongCon = ct.SoLuongNhap - ct.SoLuongXuat,
                            SoLuongXuat = ct.SoLuongXuat,
                            ThanhTien = ct.TongTienThanhToan,
                            TienNo = ct.TongTienNo,
                            DonGiaNhap = ct.DonGiaNhap
                        };
                        newThanhToan.TongTienConNo += ct.TongTienNo;
                        newThanhToan.TongTienThanhToan += ct.TongTienThanhToan;
                        ctThanhToanService.Add(ctThanhToan);
                    }
                    thanhToanService.Update(newThanhToan);
                    thanhToanService.Save();
                    Session["ThanhToan"] = null;
                    Session.RemoveAll();
                    return Redirect("/bao-cao/nxb/");
                }
            }
            return View(thanhToanVm);
        }

        [Route("chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult ChiTietBaoCao(int id)
        {
            var thanhToan = thanhToanService.GetById(id, new string[] { "NhaXuatBan", "TinhTrang" });
            var thanhToanVm = Mapper.Map<ThanhToan, ThanhToanViewModel>(thanhToan);
            thanhToanVm.NgayXacNhan = DateTime.Now;

            var ctThanhToan = ctThanhToanService.GetMultiById(thanhToanVm.Id, new string[] { "Sach" });
            thanhToanVm.CtThanhToans = Mapper.Map<IEnumerable<CtThanhToan>, IEnumerable<CtThanhToanViewModel>>(ctThanhToan);

            Session["TinhTrangBanDau"] = thanhToanVm.IdTinhTrang;
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
                if (tinhTrangBanDau == CommonConstant.DA_THANH_TOAN || tinhTrangBanDau == CommonConstant.DA_HUY)
                {
                    ModelState.AddModelError("", "Báo cáo đã thanh toán hoặc đã bị hủy không thể cập nhật.");
                }
                else
                {
                    var updateThanhToan = new ThanhToan();
                    updateThanhToan.UpdateThanhToan(thanhToanVm);
                    thanhToanService.Update(updateThanhToan);
                    thanhToanService.Save();
                }
            }

            return RedirectToAction("ChiTietBaoCao", new { id = thanhToanVm.Id });
        }
    }
}