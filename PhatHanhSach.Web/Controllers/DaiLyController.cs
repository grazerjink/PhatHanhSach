using AutoMapper;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("dai-ly")]
    public class DaiLyController : Controller
    {
        private IDaiLyService daiLyService;

        public DaiLyController(IDaiLyService daiLyService)
        {
            this.daiLyService = daiLyService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult DanhSachDaiLy()
        {
            var dsDaiLy = daiLyService.GetAllActive();
            var dsDaiLyVm = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(dsDaiLy);
            return View(dsDaiLyVm);
        }

        [Route("them")]
        [HttpGet]
        public ActionResult ThemDaiLy()
        {
            return View();
        }

        [Route("them")]
        [HttpPost]
        public ActionResult ThemDaiLy(DaiLyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newDaiLy = new DaiLy();
                newDaiLy.UpdateDaiLy(model);
                // Insert into database
                daiLyService.Add(newDaiLy);
                // Commit
                daiLyService.Save();

                TempData["Success"] = "Đã thêm thành công đại lý.";
                return RedirectToAction("ThemDaiLy");
            }
            else
            {
                return View(model);
            }
        }

        [Route("cap-nhat/dl.{id}")]
        [HttpGet]
        public ActionResult CapNhatDaiLy(int id)
        {
            var daiLy = daiLyService.GetById(id);
            var daiLyVm = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);

            return View(daiLyVm);
        }

        [Route("cap-nhat")]
        [HttpPost]
        public ActionResult CapNhatDaiLy(DaiLyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var edittedDaiLy = new DaiLy();
                edittedDaiLy.UpdateDaiLy(model);
                daiLyService.Update(edittedDaiLy);
                daiLyService.Save();
            }

            return View(model);
        }

        [Route("xoa/dl.{id}")]
        public ActionResult XoaDaiLy(int id)
        {
            var daiLy = daiLyService.GetById(id);
            daiLy.TrangThai = false;
            daiLyService.Update(daiLy);
            daiLyService.Save();
            return RedirectToRoute("dai-ly");
        }
    }
}