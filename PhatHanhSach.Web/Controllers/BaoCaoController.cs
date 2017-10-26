﻿using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Service.Services;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("bao-cao")]
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
                if(dsSachDaMua == null || !dsSachDaMua.Any())
                {
                    ModelState.AddModelError("","Đại lý chưa có nhập sách vào khoảng thời gian này.");
                }
                else if(baoCaoDLService.CheckReportIsCreated(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau))
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
            return View(baoCaoDLVm);
        }

        [Route("them-chi-tiet")]
        [HttpPost]
        public ActionResult ThemChiTietBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            if (Request.Form["create"] != null)
            {
                var baoCao = (BaoCaoDLViewModel)Session["BaoCao"];
                var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];

                BaoCaoDL newBaoCao = new BaoCaoDL();
                newBaoCao.UpdateBaoCaoDL(baoCaoDLVm);
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

                    newBaoCao.TongTienThanhToan += (double)ctBaoCao.ThanhTien;
                    newBaoCao.TongTienConNo += (double)ctBaoCao.TienNo;

                    ctBaoCaoDLService.Add(ctBaoCao);
                }
                baoCaoDLService.Update(newBaoCao);
                baoCaoDLService.Save();

                Session["BaoCao"] = null;
                Session["dsCtBaoCao"] = null;
                Session.RemoveAll();

                return Redirect("/bao-cao/");
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
                                ((BaoCaoDLViewModel)Session["BaoCao"]).TongTienThanhToan += newCtBaoCaoDL.ThanhTien;
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
            updatedBc.TongTienThanhToan -= ctbc.ThanhTien;
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
            Session["dsCtBaoCao"] = new List<CtBaoCaoDLViewModel>();

            var dsDaiLy = daiLyService.GetAll();
            var dsDaiLyViewModel = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            ViewBag.DanhSachDaiLy = dsDaiLyViewModel;

            var baoCaoDL = baoCaoDLService.GetByCodeHasIncluded(id, new string[] { "DaiLy", "TinhTrang" });
            var baoCaoDLVM = Mapper.Map<BaoCaoDL, BaoCaoDLViewModel>(baoCaoDL);
            baoCaoDLVM.NgayXacNhan = DateTime.Now;

            var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVM.IdDaiLy, baoCaoDLVM.NgayBatDau, baoCaoDLVM.NgayKetThuc);
            ViewBag.dsSachDaMua = dsThongKeBaoCao;

            var dsCtBaoCaoDL = ctBaoCaoDLService.GetMultiById(baoCaoDL.Id, new string[] { "Sach" });
            baoCaoDLVM.CtBaoCaoDLs = Mapper.Map<IEnumerable<CtBaoCaoDL>, IEnumerable<CtBaoCaoDLViewModel>>(dsCtBaoCaoDL);

            var dsTinhTrang = tinhTrangService.GetAll();
            SelectList selectList = new SelectList(dsTinhTrang, "Id", "MoTa");
            ViewBag.ListSelectTinhTrang = selectList;

            Session["TinhTrangBanDau"] = baoCaoDLVM.IdTinhTrang;

            if (Session["dsCtBaoCaoEdited"] == null)
            {
                Session["dsCtBaoCao"] = baoCaoDLVM.CtBaoCaoDLs;
                Session["dsCtBaoCaoEdited"] = new List<CtBaoCaoDLViewModel>();
            }
            else
            {
                var dsEdited = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCaoEdited"];
                if (dsEdited.Count == 0)
                    Session["dsCtBaoCao"] = baoCaoDLVM.CtBaoCaoDLs;
                else
                    Session["dsCtBaoCao"] = dsEdited;
            }

            var errors = TempData["errors"] as List<String>;
            if (errors != null && errors.Count() != 0)
            {
                ViewBag.Errors = new List<String>();
                ViewBag.Errors = errors;
            }

            if (TempData["Changed"] != null)
            {
                ViewBag.Changed = TempData["Changed"];
            }
            else
            {
                ViewBag.Changed = false;
            }

            return View(baoCaoDLVM);
        }

        
        [Route("cap-nhat-chi-tiet")]
        [HttpPost]
        public ActionResult CapNhatBaoCao(BaoCaoDLViewModel baoCaoDLVM)
        {
            List<string> listErrors = new List<string>();
            if (ModelState.IsValid)
            {
                int tinhTrangBanDau = (int)Session["TinhTrangBanDau"];
                if (tinhTrangBanDau == CommonConstant.DA_THANH_TOAN || tinhTrangBanDau == CommonConstant.DA_HUY)
                {
                    ModelState.AddModelError("", "Báo cáo đã thanh toán hoặc đã bị hủy không thể cập nhật.");
                }
                else
                {
                    var editedBaoCaoDL = new BaoCaoDL();
                    editedBaoCaoDL.UpdateBaoCaoDL(baoCaoDLVM);
                    baoCaoDLService.Update(editedBaoCaoDL);
                    baoCaoDLService.Save();

                    /// Update CtBaoCao
                    double tongTienThanhToan = 0;
                    double tongTienConNo = 0;
                    var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];
                    var dsSachChuaKhaiSL = baoCaoDLService.GetListAnalysisReport(baoCaoDLVM.IdDaiLy, baoCaoDLVM.NgayBatDau, baoCaoDLVM.NgayKetThuc);

                    foreach (var ctbc in dsSachDaKhaiSL)
                    {
                        tongTienThanhToan += ctbc.ThanhTien;
                        tongTienConNo += ctbc.TienNo;

                        dsSachChuaKhaiSL.RemoveAll(t => t.Id == ctbc.IdSach);

                        CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                        ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                        ctBaoCaoDLService.Add(ctBaoCao);
                    }

                    foreach (var s in dsSachChuaKhaiSL)
                    {
                        var giaBan = sachService.GetById(s.Id).GiaBan;

                        CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                        ctBaoCao.DonGiaXuat = (double)giaBan;
                        ctBaoCao.ThanhTien = 0;
                        ctBaoCao.SoLuongCon = s.SoLuongMua;
                        ctBaoCao.TienNo = ctBaoCao.DonGiaXuat * ctBaoCao.SoLuongCon;
                        ctBaoCao.SoLuongBan = 0;
                        ctBaoCao.IdBaoCao = baoCaoDLVM.Id;
                        ctBaoCao.IdSach = s.Id;

                        tongTienThanhToan += (double)ctBaoCao.ThanhTien;
                        tongTienConNo += (double)ctBaoCao.TienNo;

                        ctBaoCaoDLService.Add(ctBaoCao);
                    }

                    editedBaoCaoDL.TongTienThanhToan = tongTienThanhToan;
                    editedBaoCaoDL.TongTienConNo = tongTienConNo;
                    baoCaoDLService.Update(editedBaoCaoDL);
                    baoCaoDLService.Save();

                    Session["dsCtBaoCao"] = null;

                    var newCongNoDL = new CongNoDL();
                    newCongNoDL.IdDaiLy = editedBaoCaoDL.IdDaiLy;
                    newCongNoDL.NgayCapNhat = editedBaoCaoDL.NgayXacNhan;
                    newCongNoDL.TongTienConNo = editedBaoCaoDL.TongTienConNo;
                    newCongNoDL.TongTienThanhToan = editedBaoCaoDL.TongTienThanhToan;
                    congNoDLService.Add(newCongNoDL);
                    congNoDLService.Save();
                }
            }
            else
            {
                foreach (var e in ModelState.Values)
                {
                    listErrors.Add(e.Value.ToString());
                }
            }

            TempData["errors"] = listErrors;

            return RedirectToAction("ChiTietBaoCao", new { id = baoCaoDLVM.Id });
        }

        /*
        [Route("cap-nhat-sach-ban")]
        [HttpPost]
        public ActionResult CapNhatSachBan(BaoCaoDLViewModel baoCaoDLVm)
        {
            List<string> listErrors = new List<string>();
            var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
            if (ModelState.IsValid)
            {
                var sach = sachService.GetById(baoCaoDLVm.ctBaoCao.IdSach);
                if (sach == null)
                {
                    listErrors.Add("Thông tin sách không tồn tại.");
                }
                else
                {
                    int soLuongDaMua = dsThongKeBaoCao.Find(x => x.IdSach == baoCaoDLVm.ctBaoCao.IdSach).SoLuongMua;
                    if (baoCaoDLVm.ctBaoCao.SoLuongBan > soLuongDaMua)
                    {
                        listErrors.Add("Số lượng bán không được lớn hơn số lượng đã mua là " + soLuongDaMua);
                    }
                    else
                    {
                        var listSachKhaiBao = Session["dsCtBaoCao"] as List<CtBaoCaoDLViewModel>;
                        var sachBanDau = dsThongKeBaoCao.Find(x => x.IdSach == sach.Id);
                        var newEditSach = listSachKhaiBao.Find(x => x.IdSach == sach.Id);

                        listSachKhaiBao.RemoveAll(x => x.IdSach == sach.Id);

                        newEditSach.SoLuongBan = baoCaoDLVm.ctBaoCao.SoLuongBan;
                        newEditSach.ThanhTien = (double)(newEditSach.SoLuongBan * sach.GiaBan);
                        newEditSach.SoLuongCon = sachBanDau.SoLuongMua - newEditSach.SoLuongBan;
                        newEditSach.TienNo = (double)(sachBanDau.SoLuongMua * sach.GiaBan) - newEditSach.ThanhTien;

                        listSachKhaiBao.Add(newEditSach);
                        Session["dsCtBaoCaoEdited"] = listSachKhaiBao;
                        TempData["Changed"] = true;
                        return RedirectToAction("ChiTietBaoCao", new { id = baoCaoDLVm.Id });
                    }
                }
            }
            else
            {
                foreach (var e in ModelState.Values)
                {
                    listErrors.Add(e.Value.ToString());
                }
            }

            TempData["errors"] = listErrors;
            TempData["Changed"] = false;

            return RedirectToAction("ChiTietBaoCao", new { id = baoCaoDLVm.Id });
        }*/
    }
}