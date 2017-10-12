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
        public ActionResult Index()
        {
            return View();
        }        
    }
}