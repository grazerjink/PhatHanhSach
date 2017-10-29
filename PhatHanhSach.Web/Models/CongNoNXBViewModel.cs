using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CongNoNXBViewModel
    {
        public int Id { get; set; }
        public int IdNXB { get; set; }
        public double TongTienThanhToan { get; set; }
        public double TongTienConNo { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}