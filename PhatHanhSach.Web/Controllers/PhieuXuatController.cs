using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("phieu-xuat")]
    public class PhieuXuatController : Controller
    {
        IPhieuXuatService phieuXuatService;
        ISachService sachService;
        IDaiLyService daiLyService;
        ICtPhieuXuatService ctPhieuXuatService;
        ITonKhoService tonKhoService;
        ICongNoDLService congNoDLService;

        public PhieuXuatController(
            IPhieuXuatService phieuXuatService,
            ISachService sachService,
            IDaiLyService daiLyService,
            ICtPhieuXuatService ctPhieuXuatService,
            ITonKhoService tonKhoService,
            ICongNoDLService congNoDLService)
        {
            this.phieuXuatService = phieuXuatService;
            this.sachService = sachService;
            this.daiLyService = daiLyService;
            this.ctPhieuXuatService = ctPhieuXuatService;
            this.tonKhoService = tonKhoService;
            this.congNoDLService = congNoDLService;
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
        public ActionResult ThemPhieuXuat(PhieuXuatViewModel pxViewModel, string TenDaiLy)
        {
            if (ModelState.IsValid)
            {
                var daiLy = daiLyService.GetSingleByName(TenDaiLy);                
                if (daiLy == null)
                {
                    ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                }
                else
                {
                    pxViewModel.IdDaiLy = daiLy.Id;
                    var soTienNo = congNoDLService.GetSingleByIdAndDate(daiLy.Id, pxViewModel.ThoiGianXuat).TongTienConNo;
                    if (soTienNo > CommonConstant.NO_CHO_PHEP)
                    {
                        ModelState.AddModelError("", "Đã vượt quá số tiền cho phép nợ, không thể lập phiếu nữa.");
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
            }

            return View(pxViewModel);
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
        public ActionResult ThemChiTietPhieuXuat(PhieuXuatViewModel pxViewModel, string TenSach)
        {
            if (ModelState.IsValid)
            {
                var sach = sachService.GetSingleByName(TenSach);
                if (sach == null)
                {
                    ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                }
                else
                {
                    pxViewModel.ctPhieuXuat.IdSach = sach.Id;

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

                                TempData["Success"] = "Đã lưu thành công một chi tiết.";
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
            return View(pxViewModel);
        }

        [HttpPost]
        public ActionResult TaoPhieuXuat()
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

            TempData["Success"] = "Đã thêm mới một phiếu xuất.";
            return Redirect("/phieu-xuat/");            
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
        
    }
}