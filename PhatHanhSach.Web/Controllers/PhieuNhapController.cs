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
        string maSach = "";

        public PhieuNhapController(IPhieuNhapService phieuNhapService, ISachService sachService, INhaXuatBanService nhaXuatBanService)
        {
            this.phieuNhapService = phieuNhapService;
            this.sachService = sachService;
            this.nhaXuatBanService = nhaXuatBanService;
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

                pnViewModel.MaPhieuNhap = pnViewModel.MaPhieuNhap.ToUpper();
                pnViewModel.ctPhieuNhap = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(new CtPhieuNhap());
                pnViewModel.ctPhieuNhap.MaPhieuNhap = pnViewModel.MaPhieuNhap.ToUpper();
                pnViewModel.NhaXuatBan = Mapper.Map<NhaXuatBan, NhaXuatBanViewModel>(new NhaXuatBan());
                pnViewModel.NhaXuatBan.MaNXB = pnViewModel.MaNXB.ToUpper();
                Session["dsCtPhieuNhap"] = new List<CtPhieuNhapViewModel>();

                if (idNXB == null)
                {                       
                    return RedirectToAction("ThemNhaXuatBan", pnViewModel);
                }
                else
                {
                    return RedirectToAction("ThemChiTietPhieuNhap", pnViewModel);
                }
            }
            else
            {
                return View(pnViewModel);
            }
        }
        
        public ActionResult ThemNhaXuatBan(PhieuNhapViewModel pnViewModel)
        {            
            return View(pnViewModel);
        }
        
        public ActionResult ThemChiTietPhieuNhap(PhieuNhapViewModel pnViewModel)
        {   
            if (Request.Form["create"] != null)
            {
                //// Thêm phiếu nhập và ct phiếu nhập vào csdl
            }
            else if(Request.Form["save"] != null)
            {
                CtPhieuNhap newCtPhieuNhap = new CtPhieuNhap();
                newCtPhieuNhap.UpdateCtPhieuNhap(pnViewModel.ctPhieuNhap);
                newCtPhieuNhap.MaPhieuNhap = pnViewModel.MaPhieuNhap.ToUpper();

                if (!newCtPhieuNhap.MaSach.ToUpper().Equals(maSach))
                {
                    maSach = newCtPhieuNhap.MaSach.ToUpper();
                    var newCtPhieuNhapViewModel = Mapper.Map<CtPhieuNhap, CtPhieuNhapViewModel>(newCtPhieuNhap);
                    ((List<CtPhieuNhapViewModel>)Session["dsCtPhieuNhap"]).Add(newCtPhieuNhapViewModel);
                    return RedirectToAction("ThemChiTietPhieuNhap", pnViewModel);
                }
                else
                {
                    ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                }
            }
            var dsSach = sachService.GetAll();
            ViewBag.dsSach = Mapper.Map<IEnumerable<Sach>, IEnumerable<SachViewModel>>(dsSach);
            return View(pnViewModel);
        }
    }
}