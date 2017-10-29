using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class TonKhoViewModel
    {
        public int Id { get; set; }
        public int IdSach { get; set; }
        public int SoLuong { get; set; }
        public DateTime ThoiGian { get; set; }
        public int TangGiam { get; set; }

        public SachViewModel Sach { get; set; }
    }
}