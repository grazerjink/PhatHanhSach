using PhatHanhSach.Data.Models;
using PhatHanhSach.Web.Models;

namespace PhatHanhSach.Web.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDaiLy(this DaiLy daiLy, DaiLyViewModel daiLyVm)
        {
            daiLy.MaDaiLy = daiLyVm.MaDaiLy;
            daiLy.TenDaiLy = daiLyVm.TenDaiLy;
            daiLy.SoDienThoai = daiLyVm.SoDienThoai;
            daiLy.DiaChi = daiLyVm.DiaChi;
            daiLy.TrangThai = true;
        }

        public static void UpdatePhieuNhap(this PhieuNhap pn, PhieuNhapViewModel pnVm)
        {
            pn.MaPhieuNhap = pnVm.MaPhieuNhap;
            pn.MaNXB = pnVm.MaNXB;
            pn.NguoiGiao = pnVm.NguoiGiao;
            pn.ThoiGianNhap = pnVm.ThoiGianNhap;
            pn.TongSoLuong = pnVm.TongSoLuong;
            pn.TongTien = pnVm.TongTien;
            pn.TrangThai = true;
        }

        public static void UpdatePhieuXuat(this PhieuXuat px, PhieuXuatViewModel pxVm)
        {
            px.MaPhieuXuat = pxVm.MaPhieuXuat;
            px.MaDaiLy = pxVm.MaDaiLy;
            px.NguoiNhan = pxVm.NguoiNhan;
            px.ThoiGianXuat = pxVm.ThoiGianXuat;
            px.TongSoLuong = pxVm.TongSoLuong;
            px.TongTien = pxVm.TongTien;
            px.TrangThai = true;
        }

        public static void UpdateNhaXuatBan(this NhaXuatBan nxb, NhaXuatBanViewModel nxbVm)
        {
            nxb.MaNXB = nxbVm.MaNXB;
            nxb.TenNXB = nxbVm.TenNXB;
            nxb.SoDienThoai = nxbVm.SoDienThoai;
            nxb.DiaChi = nxbVm.DiaChi;
            nxb.SoTaiKhoan = nxbVm.SoTaiKhoan;
            nxb.TrangThai = true;
        }

        public static void UpdateSach(this Sach sach, SachViewModel sachVm)
        {
            sach.MaSach = sachVm.MaSach;
            sach.TenSach = sachVm.TenSach;
            sach.TacGia = sachVm.TacGia;
            sach.LinhVuc = sachVm.LinhVuc;
            sach.GiaBan = sachVm.GiaBan;
            sach.TrangThai = true;
        }

        public static void UpdateTonKho(this TonKho tonKho, TonKhoViewModel tonKhoVm)
        {
            tonKho.Id = tonKhoVm.Id;
            tonKho.MaSach = tonKhoVm.MaSach;
            tonKho.SoLuong = tonKhoVm.SoLuong;
            tonKho.ThoiGian = tonKhoVm.ThoiGian;
        }

        public static void UpdateCtPhieuNhap(this CtPhieuNhap ctPhieuNhap, CtPhieuNhapViewModel ctPhieuNhapVm)
        {
            ctPhieuNhap.MaPhieuNhap = ctPhieuNhapVm.MaPhieuNhap;
            ctPhieuNhap.Id = ctPhieuNhapVm.Id;
            ctPhieuNhap.MaSach = ctPhieuNhapVm.MaSach;
            ctPhieuNhap.SoLuongNhap = ctPhieuNhapVm.SoLuongNhap;
            ctPhieuNhap.ThanhTien = ctPhieuNhapVm.ThanhTien;
            ctPhieuNhap.GiaNhap = ctPhieuNhapVm.GiaNhap;
        }

        public static void UpdateCtPhieuXuat(this CtPhieuXuat ctPhieuXuat, CtPhieuXuatViewModel ctPhieuXuatVm)
        {
            ctPhieuXuat.MaPhieuXuat = ctPhieuXuatVm.MaPhieuXuat;
            ctPhieuXuat.Id = ctPhieuXuatVm.Id;
            ctPhieuXuat.MaSach = ctPhieuXuatVm.MaSach;
            ctPhieuXuat.SoLuongXuat = ctPhieuXuatVm.SoLuongXuat;
            ctPhieuXuat.ThanhTien = ctPhieuXuatVm.ThanhTien;
            ctPhieuXuat.GiaXuat = ctPhieuXuatVm.GiaXuat;
        }

        public static void UpdateCtBaoCaoDL(this CtBaoCaoDL ctBaoCaoDL, CtBaoCaoDLViewModel ctBaoCaoDLVm)
        {
            ctBaoCaoDL.MaBaoCao = ctBaoCaoDLVm.MaBaoCao;
            ctBaoCaoDL.MaSach = ctBaoCaoDLVm.MaSach;
            ctBaoCaoDL.DonGiaXuat = ctBaoCaoDLVm.DonGiaXuat;
            ctBaoCaoDL.SoLuongBan = ctBaoCaoDLVm.SoLuongBan;
            ctBaoCaoDL.SoLuongCon = ctBaoCaoDLVm.SoLuongCon;
            ctBaoCaoDL.TienNo = ctBaoCaoDLVm.TienNo;
            ctBaoCaoDL.ThanhTien = ctBaoCaoDLVm.ThanhTien;
        }

        public static void UpdateCtDoanhThu(this CtDoanhThu ctDoanhThu, CtDoanhThuViewModel ctDoanhThuVm)
        {
            //// TODO:
        }

        public static void UpdateCtThanhToan(this CtThanhToan ctThanhToan, CtThanhToanViewModel ctThanhToanVm)
        {
            //// TODO:
        }

        public static void UpdateBaoCaoDL(this BaoCaoDL baoCaoDL, BaoCaoDLViewModel baoCaoDLVm)
        {
            baoCaoDL.MaBaoCao = baoCaoDLVm.MaBaoCao;
            baoCaoDL.MaDaiLy = baoCaoDLVm.MaDaiLy;
            baoCaoDL.ThoiGianBatDau = baoCaoDLVm.ThoiGianBatDau;
            baoCaoDL.ThoiGianKetThuc = baoCaoDLVm.ThoiGianKetThuc;
            baoCaoDL.ThoiGianLapPhieu = baoCaoDLVm.ThoiGianLapPhieu;
            baoCaoDL.TongTienConNo = baoCaoDLVm.TongTienConNo;
            baoCaoDL.TongTienThanhToan = baoCaoDLVm.TongTienThanhToan;
            baoCaoDL.TrangThai = true;
        }

        public static void UpdateCongNoDL(this CongNoDL congNoDL, CongNoDLViewModel congNoDLVm)
        {
            //// TODO:
        }

        public static void UpdateCongNoNXB(this CongNoNXB congNoNXB, CongNoNXBViewModel congNoNXBVm)
        {
            //// TODO:
        }

        public static void UpdateThanhToan(this ThanhToan thanhToan, ThanhToanViewModel thanhToanVm)
        {
            thanhToan.TrangThai = true;
        }

        public static void UpdateDoanhThu(this DoanhThu doanhThu, DoanhThuViewModel doanhThuVm)
        {
            //// TODO:
        }
    }
}