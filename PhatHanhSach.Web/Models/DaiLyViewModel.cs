using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class DaiLyViewModel
    {
        public string MaDaiLy { get; set; }
        public string TenDaiLy { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }
    }
}