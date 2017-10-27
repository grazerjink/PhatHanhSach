using PhatHanhSach.Common;
using System;
using System.Collections.Generic;

namespace PhatHanhSach.Web.Models
{
    public class ThanhToanViewModel
    {
        public int Id { get; set; }
        public int IdNXB { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime ThoiGianLapPhieu { get; set; }
        public double TongTienThanhToan { get; set; }
        public double TongTienConNo { get; set; }
        public int IdTinhTrang { get; set; }
        public DateTime NgayXacNhan { get; set; }
        public bool TrangThai { get; set; }

        public IEnumerable<CtThanhToanViewModel> CtThanhToans { get; set; }
        public IEnumerable<ThongKeBaoCaoNXBViewModel> dsThongKeNXB { get; set; }
        public NhaXuatBanViewModel NhaXuatBan { get; set; }
        public TinhTrangViewModel TinhTrang { get; set; }
    }
}