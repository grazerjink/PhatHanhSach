using System;
using System.Collections.Generic;

namespace PhatHanhSach.Web.Models
{
    public class BaoCaoDLViewModel
    {
        public int Id { get; set; }
        public int IdDaiLy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }
        public double TongTienThanhToan { get; set; }
        public double TongTienConNo { get; set; }
        public int IdTinhTrang { get; set; }
        public DateTime NgayXacNhan { get; set; }
        public bool TrangThai { get; set; }

        public DaiLyViewModel DaiLy { get; set; }
        public CtBaoCaoDLViewModel ctBaoCao { get; set; }
        public IEnumerable<CtBaoCaoDLViewModel> CtBaoCaoDLs { get; set; }
        public TinhTrangViewModel TinhTrang { get; set; }
    }
}