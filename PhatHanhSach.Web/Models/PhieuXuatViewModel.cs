using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class PhieuXuatViewModel
    {
        public string MaPhieuXuat { get; set; }
        public string MaDaiLy { get; set; }
        public string NguoiNhan { get; set; }
        public int TongSoLuong { get; set; }
        public double TongTien { get; set; }
        public DateTime ThoiGianXuat { get; set; }
        public bool TrangThai { get; set; }
    }
}