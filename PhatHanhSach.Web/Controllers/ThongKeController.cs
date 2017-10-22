using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("thong-ke")]
    public class ThongKeController : Controller
    {
        [Route("ton-kho")]
        public ActionResult TonKho()
        {
            return View();
        }

        [Route("doanh-thu")]
        public ActionResult DoanhThu()
        {
            return View();
        }

        [Route("cong-no-dai-ly")]
        public ActionResult CongNoDaiLy()
        {
            return View();
        }

        [Route("cong-no-nxb")]
        public ActionResult CongNoNXB()
        {
            return View();
        }
    }
}