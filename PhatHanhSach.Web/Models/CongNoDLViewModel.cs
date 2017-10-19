using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CongNoDLViewModel
    {
        public int Id { get; set; }
        public string MaDaiLy { get; set; }
        public string MaBaoCao { get; set; }
        public double TongTienThanhToan { get; set; }
        public double TongTienConNo { get; set; }
        public DateTime NgayLap { get; set; }
    }
}