using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class TonKhoViewModel
    {
        public int Id { get; set; }
        public string MaSach { get; set; }
        public double GiaNhap { get; set; }
        public double GiaXuat { get; set; }
        public int SoLuong { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}