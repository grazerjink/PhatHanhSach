using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class BaoCaoDLViewModel
    {
        public string MaBaoCao { get; set; }
        public string MaDaiLy { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public DateTime ThoiGianLap { get; set; }
        public double TongTien { get; set; }
        public bool TrangThai { get; set; }
    }
}