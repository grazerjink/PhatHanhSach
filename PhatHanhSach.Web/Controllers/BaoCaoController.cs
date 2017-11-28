using AutoMapper;
using PhatHanhSach.Common;
using PhatHanhSach.Model;
using PhatHanhSach.Service;
using PhatHanhSach.Service.Services;
using PhatHanhSach.Web.Extensions;
using PhatHanhSach.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PhatHanhSach.Web.Controllers
{
    [RoutePrefix("bao-cao/dai-ly")]
    public class BaoCaoController : Controller
    {
        private IBaoCaoDLService baoCaoDLService;
        private ISachService sachService;
        private IDaiLyService daiLyService;
        private ICtBaoCaoDLService ctBaoCaoDLService;
        private ITinhTrangService tinhTrangService;
        private ICongNoDLService congNoDLService;
        private IPhieuXuatService phieuXuatService;

        public BaoCaoController(
            IBaoCaoDLService baoCaoDLService,
            ISachService sachService,
            IDaiLyService daiLyService,
            ICtBaoCaoDLService ctBaoCaoDLService,
            ITinhTrangService tinhTrangService,
            ICongNoDLService congNoDLService,
            IPhieuXuatService phieuXuatService)
        {
            this.baoCaoDLService = baoCaoDLService;
            this.sachService = sachService;
            this.daiLyService = daiLyService;
            this.ctBaoCaoDLService = ctBaoCaoDLService;
            this.tinhTrangService = tinhTrangService;
            this.congNoDLService = congNoDLService;
            this.phieuXuatService = phieuXuatService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult BaoCaoDaiLy()
        {
            Session.RemoveAll();
            var dsBaoCaoDL = baoCaoDLService.GetAll(new string[] { "DaiLy", "TinhTrang" });
            var dsBaoCaoDLViewModel = Mapper.Map<IEnumerable<BaoCaoDL>, IEnumerable<BaoCaoDLViewModel>>(dsBaoCaoDL);
            return View(dsBaoCaoDLViewModel);
        }

        [Route("tao-bao-cao")]
        [HttpGet]
        public ActionResult TaoBaoCao()
        {
            return View();
        }

        [Route("tao-bao-cao")]
        [HttpPost]
        public ActionResult TaoBaoCao(BaoCaoDLViewModel baoCaoDLVm, string TenDaiLy)
        {
            if (ModelState.IsValid)
            {
                var daiLy = daiLyService.GetSingleByName(TenDaiLy);
                if (daiLy == null)
                {
                    ModelState.AddModelError("", "Thông tin đại lý không tồn tại.");
                }
                else
                {
                    baoCaoDLVm.IdDaiLy = daiLy.Id;
                    var ngayBatDau = baoCaoDLService.GetStartDateToCreateReport(daiLy.Id);
                    if (ngayBatDau != null)
                    {
                        if(ngayBatDau <= baoCaoDLVm.NgayKetThuc)
                            baoCaoDLVm.NgayBatDau = ngayBatDau.Value;                        
                        else
                        {
                            ModelState.AddModelError("", "Thời gian báo cáo không hợp lệ.");
                            return View(baoCaoDLVm);
                        }
                    }
                    else
                    {
                        var ngayBatDauTaoPhieuXuat = phieuXuatService.GetFirstDateToCreateReport(daiLy.Id).Value;
                        if (ngayBatDauTaoPhieuXuat != null)
                        {
                            if(ngayBatDauTaoPhieuXuat <= baoCaoDLVm.NgayKetThuc) 
                                baoCaoDLVm.NgayBatDau = ngayBatDauTaoPhieuXuat;
                            else
                            {
                                ModelState.AddModelError("", "Thời gian báo cáo không hợp lệ.");
                                return View(baoCaoDLVm);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Chưa xuất sách cho đại lý này, không thể lập báo cáo.");
                            return View(baoCaoDLVm);
                        }
                    }

                    var dsSachDaMua = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
                    if (baoCaoDLService.CheckReportIsCreated(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayKetThuc))
                    {
                        ModelState.AddModelError("", "Khoảng thời gian đã được lập báo cáo rồi.");
                    }
                    else if (dsSachDaMua == null || dsSachDaMua.Count == 0)
                    {
                        ModelState.AddModelError("", "Đại lý chưa có nhập sách vào khoảng thời gian này.");
                    }
                    else
                    {
                        baoCaoDLVm.DaiLy = Mapper.Map<DaiLy, DaiLyViewModel>(daiLy);
                        Session["BaoCao"] = baoCaoDLVm;
                        Session["dsCtBaoCao"] = new List<CtBaoCaoDLViewModel>();
                        return Redirect("them-chi-tiet/");
                    }
                }
            }
            return View(baoCaoDLVm);
        }

        [Route("them-chi-tiet")]
        [HttpGet]
        public ActionResult ThemChiTietBaoCao()
        {
            var baoCaoDLVm = (BaoCaoDLViewModel)Session["BaoCao"];
            return View(baoCaoDLVm);
        }

        [Route("them-chi-tiet")]
        [HttpPost]
        public ActionResult ThemChiTietBaoCao(BaoCaoDLViewModel baoCaoDLVm, string TenSach)
        {
            if (ModelState.IsValid)
            {
                var sach = sachService.GetSingleByName(TenSach);
                if (sach == null)
                {
                    ModelState.AddModelError("", "Thông tin sách không tồn tại.");
                }
                else
                {
                    // Cuốn sách tồn tại thì gán id sách vào đối tượng ctBaoCao
                    baoCaoDLVm.ctBaoCao.IdSach = sach.Id;
                    // Truy xuất cuốn sách trong danh sách đã mua của Đại lý
                    var dsThongKeBaoCao = baoCaoDLService.GetListAnalysisReport(baoCaoDLVm.IdDaiLy, baoCaoDLVm.NgayBatDau, baoCaoDLVm.NgayKetThuc);
                    var tonTaiSachXuat = dsThongKeBaoCao.Find(X => X.Id == baoCaoDLVm.ctBaoCao.IdSach);
                    if (tonTaiSachXuat == null)
                    {
                        // Sách khai không có trong danh sách phiếu xuất của đại lý
                        ModelState.AddModelError("", "Không thể khai số lượng sách chưa lập phiếu.");
                    }
                    else if (baoCaoDLVm.ctBaoCao.SoLuongXuat > (tonTaiSachXuat.SoLuongNhap + tonTaiSachXuat.SoLuongTonDotTruoc))
                    {
                        // Nếu có mà khai số lượng ảo sẽ cảnh báo
                        ModelState.AddModelError("", "Số lượng bán không thể lớn hơn số lượng đã mua là: " + (tonTaiSachXuat.SoLuongNhap + tonTaiSachXuat.SoLuongTonDotTruoc));
                    }
                    else
                    {
                        // Còn lại hợp lệ
                        var slMua = tonTaiSachXuat.SoLuongNhap + tonTaiSachXuat.SoLuongTonDotTruoc;
                        var giaBan = (double)sachService.GetById(baoCaoDLVm.ctBaoCao.IdSach).GiaBan;

                        CtBaoCaoDLViewModel newCtBaoCaoDL = new CtBaoCaoDLViewModel();
                        newCtBaoCaoDL = baoCaoDLVm.ctBaoCao;
                        newCtBaoCaoDL.IdBaoCao = baoCaoDLVm.Id;
                        newCtBaoCaoDL.DonGiaXuat = giaBan;
                        newCtBaoCaoDL.SoLuongNhap = tonTaiSachXuat.SoLuongNhap;
                        newCtBaoCaoDL.SoLuongTonDotTruoc = tonTaiSachXuat.SoLuongTonDotTruoc;
                        newCtBaoCaoDL.TongTienNhap = slMua * giaBan;

                        newCtBaoCaoDL.SoLuongXuat = baoCaoDLVm.ctBaoCao.SoLuongXuat;
                        newCtBaoCaoDL.TongTienXuat = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongXuat;
                        newCtBaoCaoDL.SoLuongCon = slMua - baoCaoDLVm.ctBaoCao.SoLuongXuat;
                        newCtBaoCaoDL.TongTienNo = newCtBaoCaoDL.DonGiaXuat * newCtBaoCaoDL.SoLuongCon;
                        newCtBaoCaoDL.Sach = Mapper.Map<Sach, SachViewModel>(sach);

                        var sachDaNhap = ((List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"]).Find(x => x.IdSach == newCtBaoCaoDL.IdSach);
                        if (sachDaNhap == null)
                        {
                            baoCaoDLVm.ctBaoCao = null;
                            ((BaoCaoDLViewModel)Session["BaoCao"]).TongTienSachBan += newCtBaoCaoDL.TongTienXuat;
                            ((BaoCaoDLViewModel)Session["BaoCao"]).TongTienConNo += newCtBaoCaoDL.TongTienNo;
                            ((List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"]).Add(newCtBaoCaoDL);

                            TempData["Success"] = "Đã lưu thành công một báo cáo đại lý.";
                            return Redirect("them-chi-tiet/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Mã sách đã được thêm vào danh sách chi tiết rồi.");
                        }
                    }
                }
            }
            return View(baoCaoDLVm);
        }

        [HttpPost]
        public ActionResult ThemMoiBaoCao()
        {
            var baoCao = (BaoCaoDLViewModel)Session["BaoCao"];
            baoCao.NgayXacNhan = baoCao.ThoiGianLapPhieu;
            baoCao.TongTienConNo += baoCao.TienNoThangTruoc;
            var dsSachDaKhaiSL = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];

            BaoCaoDL newBaoCao = new BaoCaoDL();
            newBaoCao.UpdateBaoCaoDL(baoCao);
            newBaoCao.NgayXacNhan = newBaoCao.ThoiGianLapPhieu;
            newBaoCao.IdTinhTrang = CommonConstant.DA_BAO_CAO;
            baoCaoDLService.Add(newBaoCao);
            baoCaoDLService.Save();

            var dsSachChuaKhaiSL = baoCaoDLService.GetListAnalysisReport(baoCao.IdDaiLy, baoCao.NgayBatDau, baoCao.NgayKetThuc);
            foreach (var ctbc in dsSachDaKhaiSL)
            {
                ctbc.IdBaoCao = newBaoCao.Id;
                var ctBaoCao = new CtBaoCaoDL();
                ctBaoCao.UpdateCtBaoCaoDL(ctbc);
                ctBaoCaoDLService.Add(ctBaoCao);

                dsSachChuaKhaiSL.RemoveAll(t => t.Id == ctbc.IdSach);
            }

            foreach (var s in dsSachChuaKhaiSL)
            {
                var giaBan = (double)sachService.GetById(s.Id).GiaBan;
                var ctBaoCao = new CtBaoCaoDL();
                ctBaoCao.IdBaoCao = newBaoCao.Id;
                ctBaoCao.IdSach = s.Id;
                ctBaoCao.DonGiaXuat = giaBan;
                ctBaoCao.SoLuongNhap = s.SoLuongNhap;
                ctBaoCao.SoLuongTonDotTruoc = s.SoLuongTonDotTruoc;
                ctBaoCao.TongTienNhap = (s.SoLuongNhap + s.SoLuongTonDotTruoc) * giaBan;
                ctBaoCao.SoLuongCon = s.SoLuongNhap + s.SoLuongTonDotTruoc;
                ctBaoCao.TongTienNo = giaBan * ctBaoCao.SoLuongCon;
                ctBaoCao.SoLuongXuat = 0;
                ctBaoCao.TongTienXuat = 0;

                newBaoCao.TongTienSachBan += (double)ctBaoCao.TongTienXuat;
                newBaoCao.TongTienConNo += (double)ctBaoCao.TongTienNo;

                ctBaoCaoDLService.Add(ctBaoCao);
            }
            baoCaoDLService.Update(newBaoCao);
            baoCaoDLService.Save();

            Session["BaoCao"] = null;
            Session["dsCtBaoCao"] = null;
            Session.RemoveAll();

            TempData["Success"] = "Đã thêm mới một báo cáo đại lý.";
            return Redirect("/bao-cao/dai-ly/");
        }

        [Route("xoa-chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult XoaMotChiTietBaoCao(int id)
        {
            int index = id - 1;
            var listCtBc = (List<CtBaoCaoDLViewModel>)Session["dsCtBaoCao"];
            var ctbc = listCtBc[index];

            var updatedBc = (BaoCaoDLViewModel)Session["BaoCao"];
            updatedBc.TongTienSachBan -= ctbc.TongTienXuat;
            updatedBc.TongTienConNo -= ctbc.TongTienNo;
            listCtBc.RemoveAt(index);

            Session["BaoCao"] = updatedBc;
            Session["dsCtBaoCao"] = listCtBc;

            return Redirect("them-chi-tiet/");
        }

        [Route("chi-tiet-bc.{id}")]
        [HttpGet]
        public ActionResult ChiTietBaoCao(int id)
        {
            var baoCaoDL = baoCaoDLService.GetByCodeHasIncluded(id, new string[] { "DaiLy", "TinhTrang" });
            var baoCaoDLVM = Mapper.Map<BaoCaoDL, BaoCaoDLViewModel>(baoCaoDL);

            var dsCtBaoCaoDL = ctBaoCaoDLService.GetMultiById(baoCaoDL.Id, new string[] { "Sach" });
            baoCaoDLVM.CtBaoCaoDLs = Mapper.Map<IEnumerable<CtBaoCaoDL>, IEnumerable<CtBaoCaoDLViewModel>>(dsCtBaoCaoDL);

            Session["TinhTrangBanDau"] = baoCaoDLVM.IdTinhTrang;
            Session["TongTienSachBan"] = baoCaoDLVM.TongTienSachBan;
            Session["dsCtBaoCao"] = baoCaoDLVM.CtBaoCaoDLs;

            if (TempData["Changed"] != null)
            {
                ViewBag.Changed = TempData["Changed"];
            }
            else
            {
                ViewBag.Changed = false;
            }

            var dsTinhTrang = tinhTrangService.GetAll();
            ViewBag.dsTinhTrang = dsTinhTrang;
            return View(baoCaoDLVM);
        }

        [Route("cap-nhat-chi-tiet")]
        [HttpPost]
        public ActionResult CapNhatBaoCao(BaoCaoDLViewModel baoCaoDLVm)
        {
            if (ModelState.IsValid)
            {
                int tinhTrangBanDau = (int)Session["TinhTrangBanDau"];
                if (tinhTrangBanDau == CommonConstant.DA_THANH_TOAN)
                {
                    TempData["Error"] = "Không thể cập nhật khi báo cáo đã thanh toán.";
                }
                else if (tinhTrangBanDau == CommonConstant.DA_HUY)
                {
                    TempData["Error"] = "Không thể cập nhật khi báo cáo đã hủy.";
                }
                else
                {
                    if (baoCaoDLVm.TongTienThanhToan < (double)Session["TongTienSachBan"])
                    {
                        TempData["Error"] = "Yêu cầu trả đủ số tiền sách bán được.";
                    }
                    else
                    {
                        var updateBaoCaoDL = baoCaoDLService.GetById(baoCaoDLVm.Id);
                        updateBaoCaoDL.IdTinhTrang = baoCaoDLVm.IdTinhTrang;
                        updateBaoCaoDL.NgayXacNhan = baoCaoDLVm.NgayXacNhan;
                        updateBaoCaoDL.TongTienThanhToan = baoCaoDLVm.TongTienThanhToan;
                        baoCaoDLService.Update(updateBaoCaoDL);
                        baoCaoDLService.Save();
                        Session.RemoveAll();
                        TempData["Success"] = "Cập nhật trạng thái thành công.";
                    }
                }
            }

            return RedirectToAction("ChiTietBaoCao", new { id = baoCaoDLVm.Id });
        }
    }
}