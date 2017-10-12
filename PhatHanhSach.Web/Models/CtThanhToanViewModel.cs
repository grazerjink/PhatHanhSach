using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtThanhToanViewModel
    {
        public int Id { get; set; }
        public string MaPhieuThanhToan { get; set; }
        public string MaSach { get; set; }
        public int SoLuongXuat { get; set; }
        public double DonGiaNhap { get; set; }
        public double ThanhTien { get; set; }
    }
}