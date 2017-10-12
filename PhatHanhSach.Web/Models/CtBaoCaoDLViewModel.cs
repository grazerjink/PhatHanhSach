using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class CtBaoCaoDLViewModel
    {
        public int Id { get; set; }
        public string MaBaoCao { get; set; }
        public string MaSach { get; set; }
        public int SoLuongBan { get; set; }
        public double DonGiaXuat { get; set; }
        public double ThanhTien { get; set; }
    }
}