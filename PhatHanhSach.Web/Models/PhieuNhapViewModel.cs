using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;

namespace PhatHanhSach.Web.Models
{
    public class PhieuNhapViewModel
    {
        public string MaPhieuNhap { get; set; }

        public string MaNXB { get; set; }

        public string NguoiGiao { get; set; }

        public int TongSoLuong { get; set; }

        public double TongTien { get; set; }

        public DateTime ThoiGianNhap { get; set; }

        public bool TrangThai { get; set; }

        public NhaXuatBanViewModel NhaXuatBan { get; set; }

        public CtPhieuNhapViewModel ctPhieuNhap { get; set; }
    }
}