using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class PhieuXuatController : Controller
    {
        IPhieuXuatService phieuXuatService;
        ISachService sachService;
        IDaiLyService daiLyService;
        ICtPhieuXuatService ctPhieuXuatService;
        ITonKhoService tonKhoService;

        public PhieuXuatController(
            IPhieuXuatService phieuXuatService,
            ISachService sachService,
            IDaiLyService daiLyService,
            ICtPhieuXuatService ctPhieuXuatService,
            ITonKhoService tonKhoService)
        {
            this.phieuXuatService = phieuXuatService;
            this.sachService = sachService;
            this.daiLyService = daiLyService;
            this.ctPhieuXuatService = ctPhieuXuatService;
            this.tonKhoService = tonKhoService;
        }

        [HttpGet]
        public ActionResult DanhSachPhieuXuat()
        {
            var dsPhieuXuat = phieuXuatService.GetAll(new string[] { "DaiLy" });
            var dsPhieuXuatViewModel = Mapper.Map<IEnumerable<PhieuXuat>, IEnumerable<PhieuXuatViewModel>>(dsPhieuXuat);
            return View(dsPhieuXuatViewModel);
        }

        [HttpGet]
        public ActionResult ThemPhieuXuat()
        {
            var dsDaiLy = daiLyService.GetAll();
            var dsDaiLyViewModel = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            ViewBag.DanhSachDaiLy = dsDaiLyViewModel;
            return View();
        }

        [HttpPost]
        public ActionResult ThemPhieuXuat(PhieuXuatViewModel pxViewModel)
        {
            var dsDaiLy = daiLyService.GetAll();
            var dsDaiLyViewModel = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            ViewBag.DanhSachDaiLy = dsDaiLyViewModel;

            if (ModelState.IsValid)
            {
                var ktraPX = phieuXuatService.GetByCode(pxViewModel.MaPhieuXuat.ToUpper());
                if (ktraPX == null)
                {
                    var phieuXuat = new PhieuXuat();
                    phieuXuat.UpdatePhieuXuat(pxViewModel);
                    pxViewModel.MaPhieuXuat = pxViewModel.MaPhieuXuat.ToUpper();

                    Session["dsCtPhieuXuat"] = new List<CtPhieuXuatViewModel>();
                    Session["MaSach"] = "";

                    var idDaiLy = daiLyService.GetByCode(phieuXuat.MaDaiLy);
                    if (idDaiLy == null)
                    {
                        ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                        return View(pxViewModel);
                    }
                    else
                    {
                        TempData["PhieuXuatVM"] = pxViewModel;
                        return RedirectToAction("ThemChiTietPhieuXuat");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mã phiếu xuất đã tồn tại.");
                    return View(pxViewModel);
                }
            }
            else
            {
                return View(pxViewModel);
            }
        }

        [HttpGet]
        public ActionResult ThemChiTietPhieuXuat()
        {
            var dsSach = sachService.GetAll();
            ViewBag.dsSach = Mapper.Map<IEnumerable<Sach>, IEnumerable<SachViewModel>>(dsSach);
            var pxViewModel = (PhieuXuatViewModel)TempData["PhieuXuatVM"];
            return View(pxViewModel);
        }

        [HttpPost]
        public ActionResult ThemChiTietPhieuXuat(PhieuXuatViewModel pxViewModel)
        {
            if (Request.Form["create"] != null)
            {
                double tongTien = 0;
                int tongSoLuong = 0;

                PhieuXuat newPhieuXuat = new PhieuXuat();
                newPhieuXuat.UpdatePhieuXuat(pxViewModel);
                var addedPhieuXuat = phieuXuatService.Add(newPhieuXuat);
                phieuXuatService.Save();

                foreach (var ctpx in (List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"])
                {
                    tongTien += (ctpx.GiaXuat * ctpx.SoLuongXuat);
                    tongSoLuong += ctpx.SoLuongXuat;
                    CtPhieuXuat ctPhieuXuat = new CtPhieuXuat();
                    ctPhieuXuat.UpdateCtPhieuXuat(ctpx);
                    ctPhieuXuatService.Add(ctPhieuXuat);
                }

                addedPhieuXuat.TongSoLuong = tongSoLuong;
                addedPhieuXuat.TongTien = tongTien;
                phieuXuatService.Update(addedPhieuXuat);
                phieuXuatService.Save();

                Session["dsCtPhieuXuat"] = null;
                Session["MaSach"] = null;

                return RedirectToAction("DanhSachPhieuXuat");
            }
            else if (Request.Form["save"] != null)
            {
                if (ModelState.IsValid)
                {
                    CtPhieuXuat newCtPhieuXuat = new CtPhieuXuat();
                    newCtPhieuXuat.UpdateCtPhieuXuat(pxViewModel.ctPhieuXuat);
                    newCtPhieuXuat.MaPhieuXuat = pxViewModel.MaPhieuXuat.ToUpper();

                    var giaBan = sachService.GetByCode(newCtPhieuXuat.MaSach).GiaBan;
                    newCtPhieuXuat.GiaXuat = giaBan;
                    newCtPhieuXuat.ThanhTien = newCtPhieuXuat.SoLuongXuat * newCtPhieuXuat.GiaXuat;

                    var sach = sachService.GetByCode(newCtPhieuXuat.MaSach);
                    var tonKho = tonKhoService.GetByCode(sach.MaSach, pxViewModel.ThoiGianXuat);
                    var soLuongTon = tonKho != null ? tonKho.SoLuong : 0;
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        if (!newCtPhieuXuat.MaSach.ToUpper().Equals(Session["MaSach"].ToString().ToUpper()))
                        {
                            if (soLuongTon < pxViewModel.ctPhieuXuat.SoLuongXuat)
                            {
                                ModelState.AddModelError("", "Số lượng tồn là " + soLuongTon + " không đủ đáp ứng yêu cầu.");
                            }
                            else
                            {
                                Session["MaSach"] = newCtPhieuXuat.MaSach.ToUpper();
                                var newCtPhieuXuatViewModel = Mapper.Map<CtPhieuXuat, CtPhieuXuatViewModel>(newCtPhieuXuat);
                                ((List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"]).Add(newCtPhieuXuatViewModel);

                                pxViewModel.ctPhieuXuat = null;
                                TempData["PhieuXuatVM"] = pxViewModel;
                                return RedirectToAction("ThemChiTietPhieuXuat");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách rồi.");
                }
            }
            var dsSach = sachService.GetAll();
            ViewBag.dsSach = Mapper.Map<IEnumerable<Sach>, IEnumerable<SachViewModel>>(dsSach);
            return View(pxViewModel);
        }
    }
}