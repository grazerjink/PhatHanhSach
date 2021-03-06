﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class PhieuXuatViewModel
    {
        public int Id { get; set; }
        public int IdDaiLy { get; set; }
        public string NguoiNhan { get; set; }
        public int TongSoLuong { get; set; }
        public double TongTien { get; set; }
        public DateTime ThoiGianXuat { get; set; }
        public bool TrangThai { get; set; }

        public CtPhieuXuatViewModel ctPhieuXuat { get; set; }
        public DaiLyViewModel DaiLy { get; set; }

        public IEnumerable<CtPhieuXuatViewModel> ctPhieuXuats { get; set; }
    }
}