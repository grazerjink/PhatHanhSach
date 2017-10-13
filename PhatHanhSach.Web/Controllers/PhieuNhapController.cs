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
        List<CtPhieuNhapViewModel> listCtPhieuNhap;
        string maSach = "";

        public PhieuNhapController(IPhieuNhapService phieuNhapService, ISachService sachService, INhaXuatBanService nhaXuatBanService)
        {
            this.phieuNhapService = phieuNhapService;
            this.sachService = sachService;
            this.nhaXuatBanService = nhaXuatBanService;
            listCtPhieuNhap = new List<CtPhieuNhapViewModel>();
        }

        public ActionResult DanhSachPhieuNhap()
        {
            var dsPhieuNhap = phieuNhapService.GetAll(new string[] { "NhaXuatBan" });
            var dsPhieuNhapViewModel = Mapper.Map<IEnumerable<PhieuNhap>, IEnumerable<PhieuNhapViewModel>>(dsPhieuNhap);
            return View(dsPhieuNhapViewModel);
        }

        // GET: PhieuNhap
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

                var idNXB = nhaXuatBanService.GetByCode(phieuNhap.MaNXB);
                if (idNXB == null)
                {
                    pnViewModel.ctPhieuNhap = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(new CtPhieuNhap());
                    pnViewModel.ctPhieuNhap.MaPhieuNhap = pnViewModel.MaPhieuNhap;
                    pnViewModel.NhaXuatBan = Mapper.Map<NhaXuatBan,NhaXuatBanViewModel>(new NhaXuatBan());
                    pnViewModel.NhaXuatBan.MaNXB = pnViewModel.MaNXB;    
                    return View("ThemNhaXuatBan", pnViewModel);
                }
                else
                {
                    pnViewModel.NhaXuatBan = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(new NhaXuatBan());
                    pnViewModel.NhaXuatBan.MaNXB = pnViewModel.MaNXB;
                    pnViewModel.ctPhieuNhap = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(new CtPhieuNhap());
                    pnViewModel.ctPhieuNhap.MaPhieuNhap = pnViewModel.MaPhieuNhap;
                    return View("ThemChiTietPhieuNhap", pnViewModel);
                }
            }
            else
            {
                return View(pnViewModel);
            }
        }
        
        [HttpPost]
        public ActionResult ThemNhaXuatBan(PhieuNhapViewModel pnViewModel)
        {            
            return View(pnViewModel);
        }

        [HttpPost]
        public ActionResult ThemChiTietPhieuNhap(PhieuNhapViewModel pnViewModel)
        {
            CtPhieuNhap newCtPhieuNhap = new CtPhieuNhap();
            newCtPhieuNhap.UpdateCtPhieuNhap(pnViewModel.ctPhieuNhap);

            if (Request.Form["save"] != null)
            {
                if (!newCtPhieuNhap.MaSach.Equals(maSach))
                {
                    maSach = newCtPhieuNhap.MaSach;
                    var newCtPhieuNhapViewModel = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(newCtPhieuNhap);
                    listCtPhieuNhap.Add(newCtPhieuNhapViewModel);
                    ViewBag.dsCtPhieuNhap = listCtPhieuNhap;
                }
                else
                {
                    ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                }
            }
            else if (Request.Form["create"] != null)
            {
                //// Thêm phiếu nhập và ct phiếu nhập vào csdl
            }

            return View(pnViewModel);
        }
    }
}