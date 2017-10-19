using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace PhatHanhSach.Web.Controllers
{
    public class BaoCaoController : Controller
    {
        IBaoCaoDLService baoCaoDLService;
        ISachService sachService;
        IDaiLyService daiLyService;
        ICtBaoCaoDLService ctBaoCaoDLService;

        public BaoCaoController(
            IBaoCaoDLService baoCaoDLService,
            ISachService sachService,
            IDaiLyService daiLyService,
            ICtBaoCaoDLService ctBaoCaoDLService)
        {
            this.baoCaoDLService = baoCaoDLService;
            this.sachService = sachService;
            this.daiLyService = daiLyService;
            this.ctBaoCaoDLService = ctBaoCaoDLService;
        }

        [HttpGet]
        public ActionResult BaoCaoDaiLy()
        {
            var dsBaoCaoDL = baoCaoDLService.GetAll(new string[] { "DaiLy" });
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
            if(ModelState.IsValid)
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
            ViewBag.dsSachDaMua = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.MaDaiLy, baoCaoDLVm.ThoiGianBatDau, baoCaoDLVm.ThoiGianKetThuc);
            return View(baoCaoDLVm);
        }

        [HttpPost]
        public ActionResult ThemChiTietBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.MaDaiLy, baoCaoDLVm.ThoiGianBatDau, baoCaoDLVm.ThoiGianKetThuc);
            ViewBag.dsSachDaMua = dsThongKeBaoCao;     

            if (Request.Form["create"] != null)
            {
                double tongTienThanhToan = 0;
                double tongTienConNo = 0;
                var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];

                BaoCaoDL newBaoCao = new BaoCaoDL();
                newBaoCao.UpdateBaoCaoDL(baoCaoDLVm);
                var addedBaoCao = baoCaoDLService.Add(newBaoCao);
                baoCaoDLService.Save();

                var dsSachChuaKhaiSL = dsThongKeBaoCao;

                foreach (var ctbc in dsSachDaKhaiSL)
                {
                    tongTienThanhToan += ctbc.ThanhTien;
                    tongTienConNo += ctbc.TienNo;

                    dsSachChuaKhaiSL.RemoveAll(t => t.MaSach == ctbc.MaSach);

                    CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                    ctBaoCaoDLService.Add(ctBaoCao);
                }

                foreach(var s in dsSachChuaKhaiSL)
                {
                    var giaBan = sachService.GetByCode(s.MaSach).GiaBan;

                    CtBaoCaoDL ctBaoCao = new CtBaoCaoDL();
                    ctBaoCao.DonGiaXuat = (double)giaBan;
                    ctBaoCao.ThanhTien = 0;
                    ctBaoCao.SoLuongCon = s.SoLuongMua;
                    ctBaoCao.TienNo = ctBaoCao.DonGiaXuat * ctBaoCao.SoLuongCon;
                    ctBaoCao.SoLuongBan = 0;
                    ctBaoCao.MaBaoCao = baoCaoDLVm.MaBaoCao;
                    ctBaoCao.MaSach = s.MaSach;

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
                    var sach = sachService.GetByCode(baoCaoDLVm.ctBaoCao.MaSach);
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        int soLuongDaMua = dsThongKeBaoCao.Find(x => x.MaSach == baoCaoDLVm.ctBaoCao.MaSach).SoLuongMua;
                        if (baoCaoDLVm.ctBaoCao.SoLuongBan > soLuongDaMua)
                        {
                            ModelState.AddModelError("", "Số lượng bán không được lớn hơn số lượng đã mua là " + soLuongDaMua);
                            return View(baoCaoDLVm);
                        }
                        else
                        {
                            CtBaoCaoDLViewModel newCtBaoCaoDL = new CtBaoCaoDLViewModel();
                            newCtBaoCaoDL = baoCaoDLVm.ctBaoCao;
                            newCtBaoCaoDL.MaBaoCao = baoCaoDLVm.MaBaoCao.ToUpper();

                            var giaBan = sachService.GetByCode(newCtBaoCaoDL.MaSach).GiaBan;
                            newCtBaoCaoDL.DonGiaXuat = (double)giaBan;
                            newCtBaoCaoDL.ThanhTien = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongBan;
                            newCtBaoCaoDL.SoLuongCon = soLuongDaMua - baoCaoDLVm.ctBaoCao.SoLuongBan;
                            newCtBaoCaoDL.TienNo = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongCon; 

                            Session["MaSach"] = newCtBaoCaoDL.MaSach.ToUpper();
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
    }
}