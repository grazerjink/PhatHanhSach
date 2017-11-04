using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtThanhToanViewModel
    {
        public int Id { get; set; }
        public int IdThanhToan { get; set; }
        public int IdSach { get; set; }
        public double DonGiaNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public int SoLuongTonDotTruoc { get; set; }
        public double TongTienNhap { get; set; }
        public int SoLuongXuat { get; set; }
        public double TongTienXuat { get; set; }
        public int SoLuongCon { get; set; }
        public double TienNo { get; set; }

        public SachViewModel Sach { get; set; }
    }
}