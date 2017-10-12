using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtPhieuXuatViewModel
    {
        public int Id { get; set; }
        public string MaPhieuXuat { get; set; }
        public string MaSach { get; set; }
        public int SoLuongXuat { get; set; }
        public double GiaXuat { get; set; }
        public double ThanhTien { get; set; }
    }
}