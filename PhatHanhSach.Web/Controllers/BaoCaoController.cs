using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Service.Services;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
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

        [HttpGet]
        public ActionResult BaoCaoDaiLy()
        {
            var dsBaoCaoDL = baoCaoDLService.GetAll(new string[] { "DaiLy", "TinhTrang" });
            var dsBaoCaoDLViewModel = Mapper.Map<IEnumerable<BaoCaoDL>, IEnumerable<BaoCaoDLViewModel>>(dsBaoCaoDL);
            return View(dsBaoCaoDLViewModel);
        }

        [HttpGet]
        public ActionResult TaoBaoCao()
        {
            var dsDaiLy = daiLyService.GetAll();
            var dsDaiLyViewModel = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            ViewBag.DanhSachDaiLy = dsDaiLyViewModel;
            return View();
        }

        [HttpPost]
        public ActionResult TaoBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            if (ModelState.IsValid)
            {
                //
                // Kiểm tra thời gian báo cáo có tồn tại rồi hay chưa ??? Chưa làm
                //
                TempData["baoCaoDLVm"] = baoCaoDLVm;
                Session["dsCtBaoCao"] = new List<CtBaoCaoDLViewModel>();
                Session["MaSach"] = "";

                return RedirectToAction("ThemChiTietBaoCao");
            }
            return View(baoCaoDLVm);
        }

        [HttpGet]
        public ActionResult ThemChiTietBaoCao()
        {
            var baoCaoDLVm = (BaoCaoDLViewModel)TempData["baoCaoDLVm"];
            ViewBag.dsSachDaMua = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
            return View(baoCaoDLVm);
        }

        [HttpPost]
        public ActionResult ThemChiTietBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
            ViewBag.dsSachDaMua = dsThongKeBaoCao;

            if (Request.Form["create"] != null)
            {
                double tongTienThanhToan = 0;
                double tongTienConNo = 0;
                var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];

                BaoCaoDL newBaoCao = new BaoCaoDL();
                newBaoCao.UpdateBaoCaoDL(baoCaoDLVm);
                newBaoCao.IdTinhTrang = CommonConstant.DA_BAO_CAO;
                var addedBaoCao = baoCaoDLService.Add(newBaoCao);
                baoCaoDLService.Save();

                var dsSachChuaKhaiSL = dsThongKeBaoCao;

                foreach (var ctbc in dsSachDaKhaiSL)
                {
                    tongTienThanhToan += ctbc.ThanhTien;
                    tongTienConNo += ctbc.TienNo;

                    dsSachChuaKhaiSL.RemoveAll(t => t.IdSach == ctbc.IdSach);

                    CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                    ctBaoCaoDLService.Add(ctBaoCao);
                }

                foreach (var s in dsSachChuaKhaiSL)
                {
                    var giaBan = sachService.GetById(s.IdSach).GiaBan;

                    CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.DonGiaXuat = (double)giaBan;
                    ctBaoCao.ThanhTien = 0;
                    ctBaoCao.SoLuongCon = s.SoLuongMua;
                    ctBaoCao.TienNo = ctBaoCao.DonGiaXuat * ctBaoCao.SoLuongCon;
                    ctBaoCao.SoLuongBan = 0;
                    ctBaoCao.IdBaoCao = baoCaoDLVm.Id;
                    ctBaoCao.IdSach = s.IdSach;

                    tongTienThanhToan += (double)ctBaoCao.ThanhTien;
                    tongTienConNo += (double)ctBaoCao.TienNo;

                    ctBaoCaoDLService.Add(ctBaoCao);
                }

                addedBaoCao.TongTienThanhToan = tongTienThanhToan;
                addedBaoCao.TongTienConNo = tongTienConNo;
                baoCaoDLService.Update(addedBaoCao);
                baoCaoDLService.Save();

                Session["dsCtBaoCao"] = null;
                Session["MaSach"] = null;

                return RedirectToAction("BaoCaoDaiLy");
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
                        int soLuongDaMua = dsThongKeBaoCao.Find(x => x.IdSach == baoCaoDLVm.ctBaoCao.IdSach).SoLuongMua;
                        if (baoCaoDLVm.ctBaoCao.SoLuongBan > soLuongDaMua)
                        {
                            ModelState.AddModelError("", "Số lượng bán không được lớn hơn số lượng đã mua là " + soLuongDaMua);
                            return View(baoCaoDLVm);
                        }
                        else
                        {
                            CtBaoCaoDLViewModel newCtBaoCaoDL = new CtBaoCaoDLViewModel();
                            newCtBaoCaoDL = baoCaoDLVm.ctBaoCao;
                            newCtBaoCaoDL.IdBaoCao = baoCaoDLVm.Id;

                            var giaBan = sachService.GetById(newCtBaoCaoDL.IdSach).GiaBan;
                            newCtBaoCaoDL.DonGiaXuat = (double)giaBan;
                            newCtBaoCaoDL.ThanhTien = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongBan;
                            newCtBaoCaoDL.SoLuongCon = soLuongDaMua - baoCaoDLVm.ctBaoCao.SoLuongBan;
                            newCtBaoCaoDL.TienNo = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongCon;

                            Session["MaSach"] = newCtBaoCaoDL.IdSach;
                            ((List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"]).Add(newCtBaoCaoDL);

                            baoCaoDLVm.ctBaoCao = null;
                            TempData["baoCaoDLVm"] = baoCaoDLVm;
                            return RedirectToAction("ThemChiTietBaoCao");
                        }
                    }
                }
            }

            return View(baoCaoDLVm);
        }

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

                        dsSachChuaKhaiSL.RemoveAll(t => t.IdSach == ctbc.IdSach);

                        CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                        ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                        ctBaoCaoDLService.Add(ctBaoCao);
                    }

                    foreach (var s in dsSachChuaKhaiSL)
                    {
                        var giaBan = sachService.GetById(s.IdSach).GiaBan;

                        CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                        ctBaoCao.DonGiaXuat = (double)giaBan;
                        ctBaoCao.ThanhTien = 0;
                        ctBaoCao.SoLuongCon = s.SoLuongMua;
                        ctBaoCao.TienNo = ctBaoCao.DonGiaXuat * ctBaoCao.SoLuongCon;
                        ctBaoCao.SoLuongBan = 0;
                        ctBaoCao.IdBaoCao = baoCaoDLVM.Id;
                        ctBaoCao.IdSach = s.IdSach;

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
        }

        [HttpGet]
        public JsonResult GetThongTinDaiLy(int id)
        {
            var daiLy = daiLyService.GetById(id);
            var daiLyVM = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            return Json(daiLyVM, JsonRequestBehavior.AllowGet);
        }
    }
}