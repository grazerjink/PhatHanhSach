using AutoMapper;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;

namespace PhatHanhSach.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DaiLy, DaiLyViewModel>();
            CreateMap<NhaXuatBan, NhaXuatBanViewModel>();
            CreateMap<PhieuNhap, PhieuNhapViewModel>();
            CreateMap<PhieuXuat, PhieuXuatViewModel>();
            CreateMap<CtPhieuNhap, CtPhieuNhapViewModel>();
            CreateMap<CtPhieuXuat, CtPhieuXuatViewModel>();
            CreateMap<Sach, SachViewModel>();
            CreateMap<TinhTrang, TinhTrangViewModel>();
            /*CreateMap<CtDoanhThu, CtDoanhThuViewModel>();
            CreateMap<CtThanhToan, CtThanhToanViewModel>();
            CreateMap<CtBaoCaoDL, CtBaoCaoDLViewModel>();
            CreateMap<BaoCaoDL, BaoCaoDLViewModel>();
            CreateMap<CongNoDL, CongNoDLViewModel>();
            CreateMap<CongNoNXB, CongNoNXBViewModel>();
            CreateMap<DoanhThu, DoanhThuViewModel>();
            CreateMap<TonKho, TonKhoViewModel>();
            CreateMap<ThanhToan, ThanhToanViewModel>();
            CreateMap<Sach, SachViewModel>();
            CreateMap<TinhTrang, TinhTrangViewModel>();*/
        }
    }
}