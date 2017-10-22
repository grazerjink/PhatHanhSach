namespace PhatHanhSach.Web.Models
{
    public class CtPhieuNhapViewModel
    {
        public int Id { get; set; }
        public int IdPhieuNhap { get; set; }
        public int IdSach { get; set; }
        public int SoLuongNhap { get; set; }
        public double DonGiaNhap { get; set; }
        public double ThanhTien { get; set; }

        public SachViewModel Sach { get; set; }
    }
}