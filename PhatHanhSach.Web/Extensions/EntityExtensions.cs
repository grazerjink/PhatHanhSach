using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;

namespace PhatHanhSach.Web.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDaiLy(this DaiLy daiLy, DaiLyViewModel daiLyVm)
        {
            daiLy.Id = daiLyVm.Id;
            daiLy.TenDaiLy = daiLyVm.TenDaiLy;
            daiLy.SoDienThoai = daiLyVm.SoDienThoai;
            daiLy.DiaChi = daiLyVm.DiaChi;
            daiLy.TrangThai = true;
        }

        public static void UpdatePhieuNhap(this PhieuNhap pn, PhieuNhapViewModel pnVm)
        {
            pn.Id = pnVm.Id;
            pn.IdNXB = pnVm.IdNXB;
            pn.NguoiGiao = pnVm.NguoiGiao;
            pn.ThoiGianNhap = pnVm.ThoiGianNhap;
            pn.TongSoLuong = pnVm.TongSoLuong;
            pn.TongTien = pnVm.TongTien;
            pn.TrangThai = true;
        }

        public static void UpdateNhaXuatBan(this NhaXuatBan nxb, NhaXuatBanViewModel nxbVm)
        {
            nxb.Id = nxbVm.Id;
            nxb.TenNXB = nxbVm.TenNXB;
            nxb.SoDienThoai = nxbVm.SoDienThoai;
            nxb.DiaChi = nxbVm.DiaChi;
            nxb.SoTaiKhoan = nxbVm.SoTaiKhoan;
            nxb.TrangThai = true;
        }

        public static void UpdateSach(this Sach sach, SachViewModel sachVm)
        {
            sach.Id = sachVm.Id;
            sach.TenSach = sachVm.TenSach;
            sach.TacGia = sachVm.TacGia;
            sach.LinhVuc = sachVm.LinhVuc;
            sach.GiaBan = sachVm.GiaBan;
            sach.TrangThai = true;
        }

        public static void UpdateCtPhieuNhap(this CtPhieuNhap ctPhieuNhap, CtPhieuNhapViewModel ctPhieuNhapVm)
        {
            ctPhieuNhap.Id = ctPhieuNhapVm.Id;
            ctPhieuNhap.IdPhieuNhap = ctPhieuNhapVm.IdPhieuNhap;
            ctPhieuNhap.IdSach = ctPhieuNhapVm.IdSach;
            ctPhieuNhap.SoLuongNhap = ctPhieuNhapVm.SoLuongNhap;
            ctPhieuNhap.ThanhTien = ctPhieuNhapVm.ThanhTien;
            ctPhieuNhap.DonGiaNhap = ctPhieuNhapVm.DonGiaNhap;
        }

        public static void UpdatePhieuXuat(this PhieuXuat px, PhieuXuatViewModel pxVm)
        {
            px.Id = pxVm.Id;
            px.IdDaiLy = pxVm.IdDaiLy;
            px.NguoiNhan = pxVm.NguoiNhan;
            px.ThoiGianXuat = pxVm.ThoiGianXuat;
            px.TongSoLuong = pxVm.TongSoLuong;
            px.TongTien = pxVm.TongTien;
            px.TrangThai = true;
        }

        public static void UpdateCtPhieuXuat(this CtPhieuXuat ctPhieuXuat, CtPhieuXuatViewModel ctPhieuXuatVm)
        {
            ctPhieuXuat.Id = ctPhieuXuatVm.Id;
            ctPhieuXuat.IdPhieuXuat = ctPhieuXuatVm.IdPhieuXuat;
            ctPhieuXuat.IdSach = ctPhieuXuatVm.IdSach;
            ctPhieuXuat.SoLuongXuat = ctPhieuXuatVm.SoLuongXuat;
            ctPhieuXuat.ThanhTien = ctPhieuXuatVm.ThanhTien;
            ctPhieuXuat.DonGiaXuat = ctPhieuXuatVm.DonGiaXuat;
        }

        public static void UpdateBaoCaoDL(this BaoCaoDL baoCaoDL, BaoCaoDLViewModel baoCaoDLVm)
        {
            baoCaoDL.Id = baoCaoDLVm.Id;
            baoCaoDL.IdDaiLy = baoCaoDLVm.IdDaiLy;
            baoCaoDL.NgayBatDau = baoCaoDLVm.NgayBatDau;
            baoCaoDL.NgayKetThuc = baoCaoDLVm.NgayKetThuc;
            baoCaoDL.ThoiGianLapPhieu = baoCaoDLVm.ThoiGianLapPhieu;
            baoCaoDL.NgayXacNhan = baoCaoDLVm.NgayXacNhan;
            baoCaoDL.TongTienConNo = baoCaoDLVm.TongTienConNo;
            baoCaoDL.TongTienThanhToan = baoCaoDLVm.TongTienThanhToan;
            baoCaoDL.IdTinhTrang = baoCaoDLVm.IdTinhTrang;
            baoCaoDL.TrangThai = true;
        }

        public static void UpdateCtBaoCaoDL(this CtBaoCaoDL ctBaoCaoDL, CtBaoCaoDLViewModel ctBaoCaoDLVm)
        {
            ctBaoCaoDL.Id = ctBaoCaoDLVm.Id;
            ctBaoCaoDL.IdBaoCao = ctBaoCaoDLVm.IdBaoCao;
            ctBaoCaoDL.IdSach = ctBaoCaoDLVm.IdSach;
            ctBaoCaoDL.DonGiaXuat = ctBaoCaoDLVm.DonGiaXuat;
            ctBaoCaoDL.SoLuongBan = ctBaoCaoDLVm.SoLuongBan;
            ctBaoCaoDL.SoLuongCon = ctBaoCaoDLVm.SoLuongCon;
            ctBaoCaoDL.TienNo = ctBaoCaoDLVm.TienNo;
            ctBaoCaoDL.ThanhTien = ctBaoCaoDLVm.ThanhTien;
        }

        public static void UpdateThanhToan(this ThanhToan thanhToan, ThanhToanViewModel thanhToanVm)
        {
            thanhToan.Id = thanhToanVm.Id;
            thanhToan.IdNXB = thanhToanVm.IdNXB;
            thanhToan.NgayBatDau = thanhToanVm.NgayBatDau;
            thanhToan.NgayKetThuc = thanhToanVm.NgayKetThuc;
            thanhToan.NgayXacNhan = thanhToanVm.NgayXacNhan;
            thanhToan.ThoiGianLapPhieu = thanhToanVm.ThoiGianLapPhieu;
            thanhToan.TongTienConNo = thanhToanVm.TongTienConNo;
            thanhToan.TongTienThanhToan = thanhToanVm.TongTienThanhToan;
            thanhToan.IdTinhTrang = thanhToanVm.IdTinhTrang;
            thanhToan.TrangThai = true;
        }

        public static void UpdateCtThanhToan(this CtThanhToan ctThanhToan, CtThanhToanViewModel ctThanhToanVm)
        {
            ctThanhToan.Id = ctThanhToanVm.Id;
            ctThanhToan.IdSach = ctThanhToanVm.IdSach;
            ctThanhToan.IdThanhToan = ctThanhToanVm.IdThanhToan;
            ctThanhToan.SoLuongCon = ctThanhToanVm.SoLuongCon;
            ctThanhToan.SoLuongXuat = ctThanhToanVm.SoLuongXuat;
            ctThanhToan.ThanhTien = ctThanhToanVm.ThanhTien;
            ctThanhToan.DonGiaNhap = ctThanhToanVm.DonGiaNhap;
            ctThanhToan.TienNo = ctThanhToanVm.TienNo;
        }

        /*       
        public static void UpdateTonKho(this TonKho tonKho, TonKhoViewModel tonKhoVm)
        {
            tonKho.Id = tonKhoVm.Id;
            tonKho.MaSach = tonKhoVm.MaSach;
            tonKho.SoLuong = tonKhoVm.SoLuong;
            tonKho.ThoiGian = tonKhoVm.ThoiGian;
        }     

        public static void UpdateCtDoanhThu(this CtDoanhThu ctDoanhThu, CtDoanhThuViewModel ctDoanhThuVm)
        {
            //// TODO:
        }

        

        public static void UpdateCongNoDL(this CongNoDL congNoDL, CongNoDLViewModel congNoDLVm)
        {
            //// TODO:
        }

        public static void UpdateCongNoNXB(this CongNoNXB congNoNXB, CongNoNXBViewModel congNoNXBVm)
        {
            //// TODO:
        }

        

        public static void UpdateDoanhThu(this DoanhThu doanhThu, DoanhThuViewModel doanhThuVm)
        {
            //// TODO:
        }
        */
    }
}