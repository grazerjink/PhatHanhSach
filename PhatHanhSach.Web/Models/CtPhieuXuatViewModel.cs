using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtPhieuXuatViewModel
    {
        public int Id { get; set; }
        public int IdPhieuXuat { get; set; }
        public int IdSach { get; set; }
        public int SoLuongXuat { get; set; }
        public double DonGiaXuat { get; set; }
        public double ThanhTien { get; set; }

        public SachViewModel Sach { get; set; }
    }
}