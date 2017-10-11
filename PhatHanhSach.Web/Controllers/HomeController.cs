using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using PhatHanhSach.Web.Extensions;

namespace PhatHanhSach.Web.Controllers
{
    public class HomeController : Controller
    {
        IDaiLyService daiLyService;

        public HomeController(IDaiLyService daiLyService)
        {
            this.daiLyService = daiLyService;
        }
        public ActionResult Index()
        {
            var dsDaiLy = daiLyService.GetAll();
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
        public ActionResult SuaDaiLy(string id)
        {
            var daiLy = daiLyService.GetByCode(id);
            var daiLyViewModel = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
            return View(daiLyViewModel);
        }

        [HttpPost]
        public ActionResult SuaDaiLy(DaiLyViewModel model)
        {
            var edittedDaiLy = new DaiLy();
            edittedDaiLy.UpdateDaiLy(model);

            daiLyService.Update(edittedDaiLy);
            daiLyService.Save();

            return View();
        }
    }
}