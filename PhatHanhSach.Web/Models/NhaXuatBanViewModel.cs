using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class NhaXuatBanViewModel
    {
        public int Id { get; set; }
        public string TenNXB { get; set; }
        public string SoDienThoai { get; set; }
        public string SoTaiKhoan { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }

        public CongNoNXBViewModel CongNoNXB { get; set; }
    }
}