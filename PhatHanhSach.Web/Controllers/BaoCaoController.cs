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
    [RoutePrefix("bao-cao/dai-ly")]
    public class BaoCaoController : Controller
    {
        private IBaoCaoDLService baoCaoDLService;
        private ISachService sachService;
        private IDaiLyService daiLyService;
        private ICtBaoCaoDLService ctBaoCaoDLService;
        private ITinhTrangService tinhTrangService;
        private ICongNoDLService congNoDLService;

        public BaoCaoController(
            IBaoCaoDLService baoCaoDLService,
            ISachService sachService,
            IDaiLyService daiLyService,
            ICtBaoCaoDLService ctBaoCaoDLService,
            ITinhTrangService tinhTrangService,
            ICongNoDLService congNoDLService)
        {
            this.baoCaoDLService = baoCaoDLService;
            this.sachService = sachService;
            this.daiLyService = daiLyService;
            this.ctBaoCaoDLService = ctBaoCaoDLService;
            this.tinhTrangService = tinhTrangService;
            this.congNoDLService = congNoDLService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult BaoCaoDaiLy()
        {
            Session.RemoveAll();
            var dsBaoCaoDL = baoCaoDLService.GetAll(new string[] { "DaiLy", "TinhTrang" });
            var dsBaoCaoDLViewModel = Mapper.Map<IEnumerable<BaoCaoDL>, IEnumerable<BaoCaoDLViewModel>>(dsBaoCaoDL);
            return View(dsBaoCaoDLViewModel);
        }

        [Route("tao-bao-cao")]
        [HttpGet]
        public ActionResult TaoBaoCao()
        {
            return View();
        }

        [Route("tao-bao-cao")]
        [HttpPost]
        public ActionResult TaoBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            if (ModelState.IsValid)
            {
                var dsSachDaMua = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
                if (dsSachDaMua == null || dsSachDaMua.Count == 0)
                {
                    ModelState.AddModelError("", "Đại lý chưa có nhập sách vào khoảng thời gian này.");
                }
                else if (baoCaoDLService.CheckReportIsCreated(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau))
                {
                    ModelState.AddModelError("", "Khoảng thời gian đã được lập báo cáo rồi.");
                }
                else
                {
                    var daiLy = daiLyService.GetById(baoCaoDLVm.IdDaiLy);
                    baoCaoDLVm.DaiLy = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);

                    Session["BaoCao"] = baoCaoDLVm;
                    Session["dsCtBaoCao"] = new List<CtBaoCaoDLViewModel>();

                    return Redirect("them-chi-tiet/");
                }
            }

            return View(baoCaoDLVm);
        }

        [Route("them-chi-tiet")]
        [HttpGet]
        public ActionResult ThemChiTietBaoCao()
        {
            var baoCaoDLVm = (BaoCaoDLViewModel)Session["BaoCao"];
            baoCaoDLVm.TienNoThangTruoc = congNoDLService.GetDeptInLastMonth(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau);
            return View(baoCaoDLVm);
        }

        [Route("them-chi-tiet")]
        [HttpPost]
        public ActionResult ThemChiTietBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            if (Request.Form["create"] != null)
            {
                var baoCao = (BaoCaoDLViewModel)Session["BaoCao"];
                baoCao.NgayXacNhan = baoCao.ThoiGianLapPhieu;
                baoCao.TongTienConNo += baoCao.TienNoThangTruoc;
                var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];

                BaoCaoDL newBaoCao = new BaoCaoDL();
                newBaoCao.UpdateBaoCaoDL(baoCao);
                newBaoCao.NgayXacNhan = newBaoCao.ThoiGianLapPhieu;
                newBaoCao.IdTinhTrang = CommonConstant.DA_BAO_CAO;
                baoCaoDLService.Add(newBaoCao);
                baoCaoDLService.Save();

                var dsSachChuaKhaiSL = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
                foreach (var ctbc in dsSachDaKhaiSL)
                {
                    ctbc.IdBaoCao = newBaoCao.Id;
                    var ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                    ctBaoCaoDLService.Add(ctBaoCao);

                    dsSachChuaKhaiSL.RemoveAll(t => t.Id == ctbc.IdSach);
                }

                foreach (var s in dsSachChuaKhaiSL)
                {
                    var giaBan = sachService.GetById(s.Id).GiaBan;
                    var ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.IdBaoCao = newBaoCao.Id;
                    ctBaoCao.IdSach = s.Id;
                    ctBaoCao.DonGiaXuat = (double)giaBan;
                    ctBaoCao.SoLuongCon = s.SoLuongMua;
                    ctBaoCao.TienNo = ctBaoCao.DonGiaXuat * ctBaoCao.SoLuongCon;
                    ctBaoCao.SoLuongBan = 0;
                    ctBaoCao.ThanhTien = 0;

                    newBaoCao.TongTienSachBan += (double)ctBaoCao.ThanhTien;
                    newBaoCao.TongTienConNo += (double)ctBaoCao.TienNo;

                    ctBaoCaoDLService.Add(ctBaoCao);
                }
                baoCaoDLService.Update(newBaoCao);
                baoCaoDLService.Save();

                Session["BaoCao"] = null;
                Session["dsCtBaoCao"] = null;
                Session.RemoveAll();

                return Redirect("/bao-cao/dai-ly/");
            }
            else if (Request.Form["save"] != null)
            {
                if (ModelState.IsValid)
                {
                    var sach = sachService.GetById(baoCaoDLVm.ctBaoCao.IdSach);
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
                        int soLuongDaMua = dsThongKeBaoCao.Find(x => x.Id == baoCaoDLVm.ctBaoCao.IdSach).SoLuongMua;
                        if (baoCaoDLVm.ctBaoCao.SoLuongBan > soLuongDaMua)
                        {
                            ModelState.AddModelError("", "Số lượng bán không được lớn hơn số lượng đã mua là " + soLuongDaMua);
                        }
                        else
                        {
                            var giaBan = sachService.GetById(baoCaoDLVm.ctBaoCao.IdSach).GiaBan;
                            CtBaoCaoDLViewModel newCtBaoCaoDL = new CtBaoCaoDLViewModel();
                            newCtBaoCaoDL = baoCaoDLVm.ctBaoCao;
                            newCtBaoCaoDL.IdBaoCao = baoCaoDLVm.Id;
                            newCtBaoCaoDL.DonGiaXuat = (double)giaBan;
                            newCtBaoCaoDL.ThanhTien = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongBan;
                            newCtBaoCaoDL.SoLuongCon = soLuongDaMua - baoCaoDLVm.ctBaoCao.SoLuongBan;
                            newCtBaoCaoDL.TienNo = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongCon;
                            newCtBaoCaoDL.Sach = Mapper.Map<Sach, SachViewModel>(sach);

                            var sachDaNhap = ((List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"]).Find(x => x.IdSach == newCtBaoCaoDL.IdSach);
                            if (sachDaNhap == null)
                            {
                                baoCaoDLVm.ctBaoCao = null;
                                ((BaoCaoDLViewModel)Session["BaoCao"]).TongTienSachBan += newCtBaoCaoDL.ThanhTien;
                                ((BaoCaoDLViewModel)Session["BaoCao"]).TongTienConNo += newCtBaoCaoDL.TienNo;
                                ((List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"]).Add(newCtBaoCaoDL);
                                return Redirect("them-chi-tiet/");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                            }
                        }
                    }
                }
            }
            return View(baoCaoDLVm);
        }

        [Route("xoa-chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult XoaMotChiTietBaoCao(int id)
        {
            int index = id - 1;
            var listCtBc = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];
            var ctbc = listCtBc[index];

            var updatedBc = (BaoCaoDLViewModel)Session["BaoCao"];
            updatedBc.TongTienSachBan -= ctbc.ThanhTien;
            updatedBc.TongTienConNo -= ctbc.TienNo;
            listCtBc.RemoveAt(index);

            Session["BaoCao"] = updatedBc;
            Session["dsCtBaoCao"] = listCtBc;

            return Redirect("them-chi-tiet/");
        }

        [Route("chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult ChiTietBaoCao(int id)
        {
            var baoCaoDL = baoCaoDLService.GetByCodeHasIncluded(id, new string[] { "DaiLy", "TinhTrang" });
            var baoCaoDLVM = Mapper.Map<BaoCaoDL, BaoCaoDLViewModel>(baoCaoDL);
            baoCaoDLVM.NgayXacNhan = DateTime.Now;

            var dsCtBaoCaoDL = ctBaoCaoDLService.GetMultiById(baoCaoDL.Id, new string[] { "Sach" });
            baoCaoDLVM.CtBaoCaoDLs = Mapper.Map<IEnumerable<CtBaoCaoDL>, IEnumerable<CtBaoCaoDLViewModel>>(dsCtBaoCaoDL);

            Session["TinhTrangBanDau"] = baoCaoDLVM.IdTinhTrang;
            Session["dsCtBaoCao"] = baoCaoDLVM.CtBaoCaoDLs;

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
            return View(baoCaoDLVM);
        }

        [Route("cap-nhat-chi-tiet")]
        [HttpPost]
        public ActionResult CapNhatBaoCao(BaoCaoDLViewModel baoCaoDLVm)
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
                    var updateBaoCaoDL = new BaoCaoDL();
                    updateBaoCaoDL.UpdateBaoCaoDL(baoCaoDLVm);
                    baoCaoDLService.Update(updateBaoCaoDL);
                    baoCaoDLService.Save();
                }
            }

            return RedirectToAction("ChiTietBaoCao", new { id = baoCaoDLVm.Id });
        }        
    }
}