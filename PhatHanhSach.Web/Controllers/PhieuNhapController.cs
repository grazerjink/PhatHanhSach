using PhatHanhSach.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class PhieuNhapController : Controller
    {
        IPhieuNhapService phieuNhapService;
        ISachService sachService;

        public PhieuNhapController(IPhieuNhapService phieuNhapService, ISachService sachService)
        {
            this.phieuNhapService = phieuNhapService;
            this.sachService = sachService;
        }

        // GET: PhieuNhap
        public ActionResult ThemPhieuNhap()
        {
            return View();
        }
    }
}