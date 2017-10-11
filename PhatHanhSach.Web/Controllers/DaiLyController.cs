using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class DaiLyController : Controller
    {
        IDaiLyService daiLyService;

        public DaiLyController(IDaiLyService daiLyService)
        {
            this.daiLyService = daiLyService;
        }

        // GET: DaiLy
        public ActionResult DanhSachDaiLy()
        {
            var dsDaiLy = daiLyService.GetAllActive();
            var dsDLViewModel = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            return View(dsDLViewModel);
        }

        [HttpGet]
        public ActionResult ThemDaiLy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemDaiLy(DaiLyViewModel model)
        {
            var newDaiLy = new DaiLy();
            newDaiLy.UpdateDaiLy(model);

            daiLyService.Add(newDaiLy);
            daiLyService.Save();

            return RedirectToAction("ThemDaiLy");
        }

        [HttpGet]
        public ActionResult CapNhatDaiLy(string id)
        {
            var daiLy = daiLyService.GetByCode(id);
            var daiLyViewModel = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
            return View(daiLyViewModel);
        }

        [HttpPost]
        public ActionResult CapNhatDaiLy(DaiLyViewModel model)
        {
            var edittedDaiLy = new DaiLy();
            edittedDaiLy.UpdateDaiLy(model);

            daiLyService.Update(edittedDaiLy);
            daiLyService.Save();

            return View();
        }
        
        public ActionResult XoaDaiLy(string id)
        {
            var daiLy = daiLyService.GetByCode(id);
            daiLy.TrangThai = false;
            daiLyService.Update(daiLy);
            daiLyService.Save();
            return RedirectToAction("DanhSachDaiLy");
        }
    }
}