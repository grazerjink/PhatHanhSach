using AutoMapper;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("phieu-nhap")]
    public class PhieuNhapController : Controller
    {
        IPhieuNhapService phieuNhapService;
        ISachService sachService;
        INhaXuatBanService nhaXuatBanService;
        ICtPhieuNhapService ctPhieuNhapService;
        ITonKhoService tonKhoService;

        public PhieuNhapController(
            IPhieuNhapService phieuNhapService,
            ICtPhieuNhapService ctPhieuNhapService,
            ISachService sachService,
            INhaXuatBanService nhaXuatBanService,
            ITonKhoService tonKhoService)
        {
            this.phieuNhapService = phieuNhapService;
            this.sachService = sachService;
            this.nhaXuatBanService = nhaXuatBanService;
            this.ctPhieuNhapService = ctPhieuNhapService;
            this.tonKhoService = tonKhoService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult DanhSachPhieuNhap()
        {
            Session.RemoveAll();
            var dsPhieuNhap = phieuNhapService.GetAll(new string[] { "NhaXuatBan" });
            var dsPhieuNhapVm = Mapper.Map<IEnumerable<PhieuNhap>, IEnumerable<PhieuNhapViewModel>>(dsPhieuNhap);
            return View(dsPhieuNhapVm);
        }

        [Route("them-phieu-nhap")]
        [HttpGet]
        public ActionResult ThemPhieuNhap()
        {
            return View();
        }

        [Route("them-phieu-nhap")]
        [HttpPost]
        public ActionResult ThemPhieuNhap(PhieuNhapViewModel pnViewModel)
        {
            if (ModelState.IsValid)
            {
                var nxb = nhaXuatBanService.GetById(pnViewModel.IdNXB);
                if (nxb == null)
                {
                    ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                    return View(pnViewModel);
                }
                else
                {
                    pnViewModel.NhaXuatBan = Mapper.Map<NhaXuatBan,NhaXuatBanViewModel>(nxb);
                    pnViewModel.TongTien = 0;
                    pnViewModel.TongSoLuong = 0;
                    Session["PhieuNhap"] = pnViewModel;
                    // Open current session to save the Import data info
                    Session["dsCtPhieuNhap"] = new List<CtPhieuNhapViewModel>();

                    return Redirect("them-chi-tiet/");
                }
            }
            else
            {
                return View(pnViewModel);
            }
        }

        [HttpGet]
        [Route("them-chi-tiet")]
        public ActionResult ThemChiTietPhieuNhap()
        {
            var pnViewModel = Session["PhieuNhap"];
            return View(pnViewModel);
        }

        [HttpPost]
        [Route("them-chi-tiet")]
        public ActionResult ThemChiTietPhieuNhap(PhieuNhapViewModel pnViewModel)
        {
            if (Request.Form["create"] != null)
            {
                var pn = (PhieuNhapViewModel) Session["PhieuNhap"];
                PhieuNhap newPhieuNhap = new PhieuNhap();
                newPhieuNhap.UpdatePhieuNhap(pn);
                phieuNhapService.Add(newPhieuNhap);
                phieuNhapService.Save();
                var newId = newPhieuNhap.Id;
                foreach (var ctpn in (List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"])
                {
                    ctpn.IdPhieuNhap = newId;
                    CtPhieuNhap ctPhieuNhap = new CtPhieuNhap();
                    ctPhieuNhap.UpdateCtPhieuNhap(ctpn);
                    ctPhieuNhapService.Add(ctPhieuNhap);

                    var sach = sachService.GetById(ctpn.IdSach);
                    if (sach.GiaNhap != ctpn.DonGiaNhap)
                    {
                        sach.GiaNhap = ctpn.DonGiaNhap;
                        sachService.Update(sach);
                    }
                }
                phieuNhapService.Save();

                Session["dsCtPhieuNhap"] = null;
                Session["MaSach"] = null;
                Session["PhieuNhap"] = null;
                Session.RemoveAll();
                return Redirect("/phieu-nhap/");
            }
            else if (Request.Form["save"] != null)
            {
                if (ModelState.IsValid)
                {                   
                    var sach = sachService.GetById(pnViewModel.ctPhieuNhap.IdSach);
                    if (sach == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                    }
                    else
                    {
                        var newCtPhieuNhapVm = new CtPhieuNhapViewModel();
                        newCtPhieuNhapVm = pnViewModel.ctPhieuNhap;
                        newCtPhieuNhapVm.ThanhTien = newCtPhieuNhapVm.SoLuongNhap * newCtPhieuNhapVm.DonGiaNhap;
                        newCtPhieuNhapVm.Sach = Mapper.Map<Sach, SachViewModel>(sach);
                        var sachDaNhap = ((List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"]).Find(x => x.IdSach == newCtPhieuNhapVm.IdSach);
                        if (sachDaNhap == null)
                        {

                            pnViewModel.ctPhieuNhap = null;
                            ((PhieuNhapViewModel)Session["PhieuNhap"]).TongTien += newCtPhieuNhapVm.ThanhTien;
                            ((PhieuNhapViewModel)Session["PhieuNhap"]).TongSoLuong += newCtPhieuNhapVm.SoLuongNhap;                            
                            ((List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"]).Add(newCtPhieuNhapVm);
                            
                            return Redirect("them-chi-tiet/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                        }
                    }
                }
            }
            return View(pnViewModel);
        }

        [Route("xoa-phieu-pn.{id}")]
        [HttpGet]
        public ActionResult XoaPhieuNhap(int id)
        {
            var delPhieuNhap = phieuNhapService.GetById(id);
            delPhieuNhap.TrangThai = false;
            // Update ton kho vs cong no
            var dsCtDaThem = ctPhieuNhapService.GetMultiByIdPhieuNhap(id);
            foreach(var ct in dsCtDaThem)
            {
                var dsTonKho = tonKhoService.GetMultiByDateAndId((DateTime)delPhieuNhap.ThoiGianNhap, (int)ct.IdSach);
                if(dsTonKho != null)
                    foreach(var tk in dsTonKho)
                    {
                        tk.TangGiam = -ct.SoLuongNhap;
                        tk.SoLuong -= ct.SoLuongNhap;
                    }
            }
            phieuNhapService.Save();
            return Redirect("/phieu-nhap/");
        }

        [Route("xoa-chi-tiet-pn.{id}")]
        [HttpGet]
        public ActionResult XoaMotChiTietPhieuNhap(int id)
        {
            int index = id - 1;
            var listCtPn = (List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"];
            var ctpn = listCtPn[index];

            var updatedPn = (PhieuNhapViewModel)Session["PhieuNhap"];
            updatedPn.TongTien -= ctpn.ThanhTien;
            updatedPn.TongSoLuong -= ctpn.SoLuongNhap;
            listCtPn.RemoveAt(index);

            Session["PhieuNhap"] = updatedPn;
            Session["dsCtPhieuNhap"] = listCtPn;

            return Redirect("them-chi-tiet/");
        }
    }
}