﻿namespace PhatHanhSach.Common
{
    public class ThongKeBaoCaoNXBViewModel
    {
        public int Id { get; set; }
        public string TenSach { get; set; }
        public double DonGiaNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public int SoLuongTonDotTruoc { get; set; }
        public double TongTienNhap { get; set; }
        public int? SoLuongXuat { get; set; }
        public double? TongTienXuat { get; set; }
        public double TongTienNo { get; set; }
    }
}