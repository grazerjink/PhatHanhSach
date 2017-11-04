namespace PhatHanhSach.Web.Models
{
    public class CtBaoCaoDLViewModel
    {
        public int Id { get; set; }
        public int IdBaoCao { get; set; }
        public int IdSach { get; set; }
        public double DonGiaXuat { get; set; }
        public int SoLuongNhap { get; set; }
        public int SoLuongTonDotTruoc { get; set; }
        public double TongTienNhap { get; set; }
        public int SoLuongXuat { get; set; }
        public double TongTienXuat { get; set; }
        public int SoLuongCon { get; set; }
        public double TongTienNo { get; set; }

        public SachViewModel Sach { get; set; }
    }
}