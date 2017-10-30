using PhatHanhSach.Service;
using System.Web.Mvc;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using PhatHanhSach.Web.Models;
using PhatHanhSach.Model;
using System;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("thong-ke")]
    public class ThongKeController : Controller
    {
        ITonKhoService tonKhoService;
        ISachService sachService;
        ICongNoDLService congNoDLService;
        IDaiLyService daiLyService;
        INhaXuatBanService nxbService;
        ICongNoNXBService congNoNXBService;
        IPhieuNhapService phieuNhapService;
        IPhieuXuatService phieuXuatService;
        IDoanhThuService doanhThuService;

        public ThongKeController(
            ITonKhoService tonKhoService, 
            ISachService sachService,
            ICongNoDLService congNoDLService,
            IDaiLyService daiLyService,
            INhaXuatBanService nxbService,
            ICongNoNXBService congNoNXBService,
            IPhieuNhapService phieuNhapService,
            IPhieuXuatService phieuXuatService,
            IDoanhThuService doanhThuService)
        {
            this.tonKhoService = tonKhoService;
            this.sachService = sachService;
            this.congNoDLService = congNoDLService;
            this.daiLyService = daiLyService;
            this.nxbService = nxbService;
            this.congNoNXBService = congNoNXBService;
            this.phieuNhapService = phieuNhapService;
            this.phieuXuatService = phieuXuatService;
            this.doanhThuService = doanhThuService;
        }


        [Route("ton-kho")]
        [HttpGet]
        public ActionResult TonKho()
        {
            return View(new List<SachViewModel>());
        }

        [Route("ton-kho")]
        [HttpPost]
        public ActionResult TonKho(DateTime NgayThongKe)
        {
            var listSach = sachService.GetAll();
            var listSachVm = Mapper.Map<IEnumerable<Sach>, IEnumerable<SachViewModel>>(listSach);
            listSachVm.ToList().ForEach(x =>
            {
                var tonKho = tonKhoService.GetSingleByIdAndDate(x.Id, NgayThongKe);
                var tonKhoVm = Mapper.Map<TonKho, TonKhoViewModel>(tonKho);
                if (tonKhoVm != null)
                    x.TonKho = tonKhoVm;
                else
                    x.TonKho = new TonKhoViewModel();
            });
            return View(listSachVm);
        }

        [Route("cong-no-dai-ly")]
        [HttpGet]
        public ActionResult CongNoDaiLy()
        {
            return View(new List<DaiLyViewModel>());
        }

        [Route("cong-no-dai-ly")]
        [HttpPost]
        public ActionResult CongNoDaiLy(DateTime NgayThongKe)
        {
            var listDaiLy = daiLyService.GetAll();
            var listDaiLyVm = Mapper.Map<IEnumerable<DaiLy>, IEnumerable<DaiLyViewModel>>(listDaiLy);
            listDaiLyVm.ToList().ForEach(x =>
            {
                var congNoDL = congNoDLService.GetSingleByIdAndDate(x.Id, NgayThongKe);
                var congNoDLVm = Mapper.Map<CongNoDL, CongNoDLViewModel>(congNoDL);
                if (congNoDLVm != null)
                    x.CongNoDL = congNoDLVm;
                else
                    x.CongNoDL = new CongNoDLViewModel();
            });
            return View(listDaiLyVm);
        }

        [Route("cong-no-nxb")]
        [HttpGet]
        public ActionResult CongNoNXB()
        {
            return View(new List<NhaXuatBanViewModel>());
        }

        [Route("cong-no-nxb")]
        [HttpPost]
        public ActionResult CongNoNXB(DateTime NgayThongKe)
        {
            var listNXB = nxbService.GetAll();
            var listNXBVm = Mapper.Map<IEnumerable<NhaXuatBan>, IEnumerable<NhaXuatBanViewModel>>(listNXB);
            listNXBVm.ToList().ForEach(x =>
            {
                var congNoNXB = congNoNXBService.GetSingleByIdAndDate(x.Id, NgayThongKe);
                var congNoNXBVm = Mapper.Map<CongNoNXB, CongNoNXBViewModel>(congNoNXB);
                if (congNoNXBVm != null)
                    x.CongNoNXB = congNoNXBVm;
                else
                    x.CongNoNXB = new CongNoNXBViewModel();
            });
            return View(listNXBVm);
        }



        [Route("doanh-thu")]
        [HttpGet]
        public ActionResult DoanhThu()
        {
            return View();
        }

        [Route("doanh-thu")]
        [HttpPost]
        public JsonResult DoanhThu(DateTime startDate, DateTime endDate)
        {
            var listRevenue = doanhThuService.GetListRevenueStatistic(startDate, endDate);

            double tt = 0;
            double tc = 0;
            var DanhSachTieuDe = new List<string>();
            var DanhSachThu = new List<double>();
            var DanhSachChi = new List<double>();
            var DanhSachLoiNhuan = new List<double>();
            listRevenue.ForEach(x =>
            {
                tt += x.TongThu;
                tc += x.TongChi;
                DanhSachTieuDe.Add(x.ThoiGian);
                DanhSachThu.Add(x.TongThu);
                DanhSachChi.Add(x.TongChi);
                DanhSachLoiNhuan.Add(x.TongThu - x.TongChi);
            });

            var TongThu = tt.ToString("N2");
            var TongChi = tc.ToString("N2");
            var TongLoiNhuan = (tt - tc).ToString("N2");
            var jsonObj = new { TongChi, TongThu, TongLoiNhuan, DanhSachTieuDe, DanhSachThu, DanhSachChi, DanhSachLoiNhuan };        
            return Json(jsonObj);
        }

    }
}