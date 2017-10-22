using PhatHanhSach.Service;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : Controller
    {
        IDaiLyService daiLyService;
        INhaXuatBanService nxbService;
        ISachService sachService;

        public ApiController(
               IDaiLyService daiLyService,
               INhaXuatBanService nxbService,
               ISachService sachService)
        {
            this.daiLyService = daiLyService;
            this.nxbService = nxbService;
            this.sachService = sachService;
        }        

        [Route("danh-sach-nxb")]
        [HttpGet]
        public JsonResult DanhSachNXB()
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var dsNXB = nxbService.GetAll();
            var listNXB = new List<object>();
            foreach(var nxb in dsNXB)
            {
                listNXB.Add(new
                {
                    label = nxb.TenNXB,
                    value = nxb.Id
                });
            }

            return Json(listNXB, JsonRequestBehavior.AllowGet);
        }

        [Route("danh-sach-dai-ly")]
        [HttpGet]
        public JsonResult DanhSachDaiLy()
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var dsDaiLy = daiLyService.GetAll();
            var listDaiLy = new List<object>();
            foreach (var dl in dsDaiLy)
            {
                listDaiLy.Add(new
                {
                    label = dl.TenDaiLy,
                    value = dl.Id
                });
            }
            return Json(listDaiLy, JsonRequestBehavior.AllowGet);
        }

        [Route("danh-sach-sach")]
        [HttpGet]
        public JsonResult DanhSachSach()
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var dsSach = sachService.GetAll();
            var listSach = new List<object>();
            foreach (var s in dsSach)
            {
                listSach.Add(new
                {
                    label = s.TenSach,
                    value = s.Id
                });
            }
            return Json(listSach, JsonRequestBehavior.AllowGet);
        }

        [Route("dai-ly/{id}")]
        [HttpGet]
        public JsonResult GetThongTinDaiLy(int id)
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var daiLy = daiLyService.GetById(id);
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            return Json(daiLy, JsonRequestBehavior.AllowGet);
        }

        [Route("nxb/{id}")]
        [HttpGet]
        public JsonResult GetThongTinNXB(int id)
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var nxb = nxbService.GetById(id);
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            return Json(nxb, JsonRequestBehavior.AllowGet);
        }

        [Route("sach/{id}")]
        [HttpGet]
        public JsonResult GetThongTinSach(int id)
        {
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            var sach = sachService.GetById(id);
            Request.ContentEncoding = Encoding.UTF8;
            Response.ContentEncoding = Encoding.UTF8;
            return Json(sach, JsonRequestBehavior.AllowGet);
        }
    }
}