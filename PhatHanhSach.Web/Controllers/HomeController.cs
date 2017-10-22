using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("trang-chu")]
        public ActionResult Index()
        {
            return View();
        }
    }
}