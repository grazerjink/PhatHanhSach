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
    }
}