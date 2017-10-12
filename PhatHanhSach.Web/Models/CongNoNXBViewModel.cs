using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CongNoNXBViewModel
    {
        public string Id { get; set; }
        public string MaNXB { get; set; }
        public string MaPhieuThanhToan { get; set; }
        public double TongTienThanhToan { get; set; }
        public double TongTienConNo { get; set; }
    }
}