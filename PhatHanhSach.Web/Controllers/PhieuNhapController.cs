using AutoMapper;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

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
        public ActionResult ThemPhieuNhap(PhieuNhapViewModel pnViewModel, string TenNXB)
        {
            if (ModelState.IsValid)
            {
                var nxb = nhaXuatBanService.GetSingleByName(TenNXB);
                if (nxb == null)
                {
                    ModelState.AddModelError("", "Thông tin nhà xuất bản không tồn tại.");
                }
                else
                {
                    pnViewModel.IdNXB = nxb.Id;
                    pnViewModel.NhaXuatBan = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(nxb);
                    pnViewModel.TongTien = 0;
                    pnViewModel.TongSoLuong = 0;
                    Session["PhieuNhap"] = pnViewModel;
                    // Open current session to save the Import data info
                    Session["dsCtPhieuNhap"] = new List<CtPhieuNhapViewModel>();

                    return Redirect("them-chi-tiet/");
                }
            }
            return View(pnViewModel);
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
        public ActionResult ThemChiTietPhieuNhap(PhieuNhapViewModel pnViewModel, string TenSach)
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
                    var dsSachCuaNXB = sachService.GetAllByIdNXB(pnViewModel.IdNXB).ToList();
                    var tonTaiSachNXB = dsSachCuaNXB.Find(X => X.Id == sach.Id);
                    if (tonTaiSachNXB == null)
                    {
                        ModelState.AddModelError("", "Thông tin sách không thuộc nhà xuất bản hiện tại.");
                    }
                    else
                    {
                        // Set Id was found into IdSach of ctPhieuNhap
                        pnViewModel.ctPhieuNhap.IdSach = sach.Id;
                        // Create a entity model and insert into db
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

                            TempData["Success"] = "Đã lưu thành công một chi tiết.";
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

        [HttpPost]
        public ActionResult TaoPhieuNhap()
        {
            var pn = (PhieuNhapViewModel)Session["PhieuNhap"];
            PhieuNhap newPhieuNhap = new PhieuNhap();
            newPhieuNhap.UpdatePhieuNhap(pn);

            phieuNhapService.Add(newPhieuNhap);
            phieuNhapService.Save();

            foreach (var ctpn in (List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"])
            {
                ctpn.IdPhieuNhap = newPhieuNhap.Id;
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
            Session["PhieuNhap"] = null;
            Session.RemoveAll();

            TempData["Success"] = "Đã thêm mới một phiếu nhập.";
            return Redirect("/phieu-nhap/");            
        }

        [HttpGet]
        [Route("chi-tiet-pn.{id}")]
        public ActionResult ChiTietPhieuNhap(int id)
        {
            var pn = phieuNhapService.GetById(id);
            var ctpn = ctPhieuNhapService.GetMultiByIdPhieuNhap(pn.Id, new string[] { "Sach" });
            var nxb = nhaXuatBanService.GetById((int)pn.IdNXB);

            var pnVm = Mapper.Map<PhieuNhap, PhieuNhapViewModel>(pn);
            pnVm.ctPhieuNhaps = Mapper.Map<IEnumerable<CtPhieuNhap>, IEnumerable<CtPhieuNhapViewModel>>(ctpn);
            pnVm.NhaXuatBan = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(nxb);
            return View(pnVm);
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