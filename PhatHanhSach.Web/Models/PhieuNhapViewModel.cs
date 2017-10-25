using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhatHanhSach.Web.Models
{
    public class PhieuNhapViewModel
    {
        public int Id { get; set; }
        public int IdNXB { get; set; }
        public string NguoiGiao { get; set; }
        public int TongSoLuong { get; set; }
        public double TongTien { get; set; }
        public DateTime ThoiGianNhap { get; set; }
        public bool TrangThai { get; set; }

        public NhaXuatBanViewModel NhaXuatBan { get; set; }
        public CtPhieuNhapViewModel ctPhieuNhap { get; set; }

        public IEnumerable<CtPhieuNhapViewModel> ctPhieuNhaps { get; set; }
    }
}