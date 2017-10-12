using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtDoanhThuViewModel
    {
        public int Id { get; set; }
        public string MaPhieuDoanhThu { get; set; }
        public string MaSach { get; set; }
        public int SoLuongNhap { get; set; }
        public double DonGiaNhap { get; set; }
        public int SoLuongXuat { get; set; }
        public double DonGiaXuat { get; set; }
        public double TienLai { get; set; }
    }
}