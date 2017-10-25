namespace PhatHanhSach.Web.Models
{
    public class CtBaoCaoDLViewModel
    {
        public int Id { get; set; }
        public int IdBaoCao { get; set; }
        public int IdSach { get; set; }
        public double DonGiaXuat { get; set; }
        public int SoLuongBan { get; set; }
        public double ThanhTien { get; set; }
        public int SoLuongCon { get; set; }
        public double TienNo { get; set; }

        public SachViewModel Sach { get; set; }
    }
}