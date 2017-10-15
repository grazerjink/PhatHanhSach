using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public ActionResult TonKho()
        {
            return View();
        }

        public ActionResult DoanhThu()
        {
            return View();
        }

        public ActionResult CongNoDaiLy()
        {
            return View();
        }

        public ActionResult CongNoNXB()
        {
            return View();
        }
    }
}