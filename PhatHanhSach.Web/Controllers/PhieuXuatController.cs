using AutoMapper;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("phieu-xuat")]
    public class PhieuXuatController : Controller
    {
        private IPhieuXuatService phieuXuatService;
        private ISachService sachService;
        private IDaiLyService daiLyService;
        private ICtPhieuXuatService ctPhieuXuatService;
        private ITonKhoService tonKhoService;

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

        [Route("")]
        [HttpGet]
        public ActionResult DanhSachPhieuXuat()
        {
            Session.RemoveAll();
            var dsPhieuXuat = phieuXuatService.GetAll(new string[] { "DaiLy" });
            var dsPhieuXuatVm = Mapper.Map<IEnumerable<PhieuXuat>, IEnumerable<PhieuXuatViewModel>>(dsPhieuXuat);
            return View(dsPhieuXuatVm);
        }

        [Route("them-phieu-xuat")]
        [HttpGet]
        public ActionResult ThemPhieuXuat()
        {
            return View();
        }

        [Route("them-phieu-xuat")]
        [HttpPost]
        public ActionResult ThemPhieuXuat(PhieuXuatViewModel pxViewModel)
        {
            if (ModelState.IsValid)
            {
                var daiLy = daiLyService.GetById(pxViewModel.IdDaiLy);
                if (daiLy == null)
                {
                    ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                    return View(pxViewModel);
                }
                else
                {
                    pxViewModel.DaiLy = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
                    pxViewModel.TongTien = 0;
                    pxViewModel.TongSoLuong = 0;
                    Session["PhieuXuat"] = pxViewModel;
                    // Open current session to save the Export data info
                    Session["dsCtPhieuXuat"] = new List<CtPhieuXuatViewModel>();

                    return Redirect("them-chi-tiet/");
                }
            }
            else
            {
                return View(pxViewModel);
            }
        }

        [Route("them-chi-tiet")]
        [HttpGet]
        public ActionResult ThemChiTietPhieuXuat()
        {
            var pxViewModel = Session["PhieuXuat"];
            return View(pxViewModel);
        }

        
        [Route("them-chi-tiet")]
        [HttpPost]
        public ActionResult ThemChiTietPhieuXuat(PhieuXuatViewModel pxViewModel)
        {
            if (Request.Form["create"] != null)
            {
                var px = (PhieuXuatViewModel)Session["PhieuXuat"];
                PhieuXuat newPhieuXuat = new PhieuXuat();
                newPhieuXuat.UpdatePhieuXuat(px);
                phieuXuatService.Add(newPhieuXuat);
                phieuXuatService.Save();

                foreach (var ctpx in (List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"])
                {
                    ctpx.IdPhieuXuat = newPhieuXuat.Id;
                    CtPhieuXuat ctPhieuXuat = new CtPhieuXuat();
                    ctPhieuXuat.UpdateCtPhieuXuat(ctpx);
                    ctPhieuXuatService.Add(ctPhieuXuat);
                }
                phieuXuatService.Save();

                Session["dsCtPhieuXuat"] = null;
                Session["PhieuXuat"] = null;
                Session.RemoveAll();

                return Redirect("/phieu-xuat/");
            }
            else if (Request.Form["save"] != null)
            {
                if (ModelState.IsValid)
                {                 
                    var sach = sachService.GetById(pxViewModel.ctPhieuXuat.IdSach);
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        var giaBan = sach.GiaBan;
                        var newCtPhieuXuatVm = new CtPhieuXuatViewModel();
                        newCtPhieuXuatVm = pxViewModel.ctPhieuXuat;
                        newCtPhieuXuatVm.DonGiaXuat = (double)giaBan;
                        newCtPhieuXuatVm.ThanhTien = newCtPhieuXuatVm.SoLuongXuat * newCtPhieuXuatVm.DonGiaXuat;
                        newCtPhieuXuatVm.Sach = Mapper.Map<Sach, SachViewModel>(sach);

                        var sachDaNhap = ((List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"]).Find(x => x.IdSach == newCtPhieuXuatVm.IdSach);
                        if (sachDaNhap == null)
                        {
                            var tonKho = tonKhoService.GetSingleByIdAndDate(sach.Id, pxViewModel.ThoiGianXuat);
                            var soLuongTon = tonKho != null ? tonKho.SoLuong : 0;

                            if (soLuongTon < newCtPhieuXuatVm.SoLuongXuat)
                            {
                                ModelState.AddModelError("", "Số lượng tồn là " + soLuongTon + " không đủ đáp ứng yêu cầu.");
                            }
                            else
                            {
                                if (!tonKhoService.CheckCreatePermission(sach.Id, newCtPhieuXuatVm.SoLuongXuat))
                                {
                                    ModelState.AddModelError("", "Thời gian xuất không cho phép tạo phiếu xuất này.");
                                }
                                else
                                {
                                    // Con phai kiem tra co cho them cac phieu truoc do
                                    pxViewModel.ctPhieuXuat = null;
                                    ((PhieuXuatViewModel)Session["PhieuXuat"]).TongTien += newCtPhieuXuatVm.ThanhTien;
                                    ((PhieuXuatViewModel)Session["PhieuXuat"]).TongSoLuong += newCtPhieuXuatVm.SoLuongXuat;
                                    ((List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"]).Add(newCtPhieuXuatVm);
                                    return Redirect("them-chi-tiet/");
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                        }
                    }
                }
            }
            return View(pxViewModel);
        }

        [HttpGet]
        [Route("chi-tiet-px.{id}")]
        public ActionResult ChiTietPhieuXuat(int id)
        {
            var px = phieuXuatService.GetById(id);
            var ctpx = ctPhieuXuatService.GetMultiByIdPhieuXuat(px.Id, new string[] { "Sach" });
            var daiLy = daiLyService.GetById((int)px.IdDaiLy);

            var pxVm = Mapper.Map<PhieuXuat, PhieuXuatViewModel>(px);
            pxVm.ctPhieuXuats = Mapper.Map<IEnumerable<CtPhieuXuat>, IEnumerable<CtPhieuXuatViewModel>>(ctpx);
            pxVm.DaiLy = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
            return View(pxVm);
        }       

        [Route("xoa-chi-tiet-px.{id}")]
        [HttpGet]
        public ActionResult XoaMotChiTietPhieuXuat(int id)
        {
            int index = id - 1;
            var listCtPx = (List<CtPhieuXuatViewModel>)Session["dsCtPhieuXuat"];
            var ctpn = listCtPx[index];

            var updatedPn = (PhieuXuatViewModel)Session["PhieuXuat"];
            updatedPn.TongTien -= ctpn.ThanhTien;
            updatedPn.TongSoLuong -= ctpn.SoLuongXuat;
            listCtPx.RemoveAt(index);

            Session["PhieuXuat"] = updatedPn;
            Session["dsCtPhieuXuat"] = listCtPx;

            return Redirect("them-chi-tiet/");
        }

        /*
        [Route("xoa-phieu-px.{id}")]
        [HttpGet]
        public ActionResult XoaPhieuXuat(int id)
        {
            var delPhieuXuat = phieuXuatService.GetById(id);
            delPhieuXuat.TrangThai = false;
            // Update ton kho vs cong no
            var dsCtDaThem = ctPhieuXuatService.GetMultiByIdPhieuXuat(id);
            foreach (var ct in dsCtDaThem)
            {
                var dsTonKho = tonKhoService.GetMultiByDateAndId((DateTime)delPhieuXuat.ThoiGianXuat, (int)ct.IdSach);
                if (dsTonKho != null)
                    foreach (var tk in dsTonKho)
                    {
                        tk.TangGiam = ct.SoLuongXuat;
                        tk.SoLuong += ct.SoLuongXuat;
                    }
            }
            phieuXuatService.Save();
            return Redirect("/phieu-xuat/");
        }*/
    }
}