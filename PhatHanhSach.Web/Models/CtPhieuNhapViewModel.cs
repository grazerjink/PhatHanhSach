using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Web.Models
{
    public class CtPhieuNhapViewModel
    {
        public int Id { get; set; }
        public string MaPhieuNhap { get; set; }
        public string MaSach { get; set; }
        public int SoLuongNhap { get; set; }
        public double GiaNhap { get; set; }
        public double ThanhTien { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual Sach Sach { get; set; }
    }
}