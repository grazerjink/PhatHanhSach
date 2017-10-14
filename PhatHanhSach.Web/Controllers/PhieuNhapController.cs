using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class PhieuNhapController : Controller
    {
        IPhieuNhapService phieuNhapService;
        ISachService sachService;
        INhaXuatBanService nhaXuatBanService;
        ICtPhieuNhapService ctPhieuNhapService;

        public PhieuNhapController(
            IPhieuNhapService phieuNhapService, 
            ICtPhieuNhapService ctPhieuNhapService, 
            ISachService sachService, 
            INhaXuatBanService nhaXuatBanService)
        {
            this.phieuNhapService = phieuNhapService;
            this.sachService = sachService;
            this.nhaXuatBanService = nhaXuatBanService;
            this.ctPhieuNhapService = ctPhieuNhapService;
        }

        public ActionResult DanhSachPhieuNhap()
        {
            var dsPhieuNhap = phieuNhapService.GetAll(new string[] { "NhaXuatBan" });
            var dsPhieuNhapViewModel = Mapper.Map<IEnumerable<PhieuNhap>, IEnumerable<PhieuNhapViewModel>>(dsPhieuNhap);
            return View(dsPhieuNhapViewModel);
        }

        [HttpGet]
        public ActionResult ThemPhieuNhap()
        {
            var dsNXB = nhaXuatBanService.GetAll();
            var dsNXBViewModel = Mapper.Map<IEnumerable<NhaXuatBan>, IEnumerable<NhaXuatBanViewModel>>(dsNXB);
            ViewBag.DanhSachNXB = dsNXBViewModel;
            return View();
        }

        [HttpPost]
        public ActionResult ThemPhieuNhap(PhieuNhapViewModel pnViewModel)
        {
            if (ModelState.IsValid)
            {
                var phieuNhap = new PhieuNhap();
                phieuNhap.UpdatePhieuNhap(pnViewModel);                
                pnViewModel.MaPhieuNhap = pnViewModel.MaPhieuNhap.ToUpper();

                Session["dsCtPhieuNhap"] = new List<CtPhieuNhapViewModel>();
                Session["MaSach"] = "";

                var idNXB = nhaXuatBanService.GetByCode(phieuNhap.MaNXB);
                if (idNXB == null)
                {
                    var dsNXB = nhaXuatBanService.GetAll();
                    var dsNXBViewModel = Mapper.Map<IEnumerable<NhaXuatBan>, IEnumerable<NhaXuatBanViewModel>>(dsNXB);
                    ViewBag.DanhSachNXB = dsNXBViewModel;

                    ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                    return View(pnViewModel);
                }
                else
                {
                    TempData["PhieuNhapVM"] = pnViewModel;
                    return RedirectToAction("ThemChiTietPhieuNhap");
                }
            }
            else
            {
                return View(pnViewModel);
            }
        }

        [HttpGet]
        public ActionResult ThemChiTietPhieuNhap()
        {
            var dsSach = sachService.GetAll();
            ViewBag.dsSach = Mapper.Map<IEnumerable<Sach>, IEnumerable<SachViewModel>>(dsSach);
            var pnViewModel = (PhieuNhapViewModel)TempData["PhieuNhapVM"];
            return View(pnViewModel);
        }

        [HttpPost]
        public ActionResult ThemChiTietPhieuNhap(PhieuNhapViewModel pnViewModel)
        {
            if (Request.Form["create"] != null)
            {
                double tongTien = 0;
                int tongSoLuong = 0;

                PhieuNhap newPhieuNhap = new PhieuNhap();
                newPhieuNhap.UpdatePhieuNhap(pnViewModel);
                var addedPhieuNhap = phieuNhapService.Add(newPhieuNhap);
                phieuNhapService.Save();

                foreach (var ctpn in (List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"])
                {
                    tongTien += (ctpn.GiaNhap * ctpn.SoLuongNhap);
                    tongSoLuong += ctpn.SoLuongNhap;
                    CtPhieuNhap ctPhieuNhap = new CtPhieuNhap();
                    ctPhieuNhap.UpdateCtPhieuNhap(ctpn);
                    ctPhieuNhapService.Add(ctPhieuNhap);
                }

                addedPhieuNhap.TongSoLuong = tongSoLuong;
                addedPhieuNhap.TongTien = tongTien;
                phieuNhapService.Update(addedPhieuNhap);
                phieuNhapService.Save();

                Session["dsCtPhieuNhap"] = null;
                Session["MaSach"] = null;

                return RedirectToAction("DanhSachPhieuNhap");
            }
            else if(Request.Form["save"] != null)
            {
                if(ModelState.IsValid)
                {                    
                    CtPhieuNhap newCtPhieuNhap = new CtPhieuNhap();
                    newCtPhieuNhap.UpdateCtPhieuNhap(pnViewModel.ctPhieuNhap);
                    newCtPhieuNhap.MaPhieuNhap = pnViewModel.MaPhieuNhap.ToUpper();
                    newCtPhieuNhap.ThanhTien = newCtPhieuNhap.SoLuongNhap * newCtPhieuNhap.GiaNhap;

                    var sach = sachService.GetByCode(newCtPhieuNhap.MaSach);
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        if (!newCtPhieuNhap.MaSach.ToUpper().Equals(Session["MaSach"].ToString().ToUpper()))
                        {
                            Session["MaSach"] = newCtPhieuNhap.MaSach.ToUpper();
                            var newCtPhieuNhapViewModel = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(newCtPhieuNhap);
                            ((List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"]).Add(newCtPhieuNhapViewModel);

                            pnViewModel.ctPhieuNhap = null;
                            TempData["PhieuNhapVM"] = pnViewModel;
                            return RedirectToAction("ThemChiTietPhieuNhap");
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
            return View(pnViewModel);
        }
    }
}