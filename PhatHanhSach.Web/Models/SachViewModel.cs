using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class SachViewModel
    {
        public int Id { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string LinhVuc { get; set; }
        public double GiaBan { get; set; }
        public double GiaNhap { get; set; }
        public bool TrangThai { get; set; }
    }
}