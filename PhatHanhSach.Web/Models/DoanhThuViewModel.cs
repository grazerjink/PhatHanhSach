using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class DoanhThuViewModel
    {
        public string MaPhieuDoanhThu { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public DateTime ThoIGianLap { get; set; }
        public double TongLai { get; set; }
    }
}