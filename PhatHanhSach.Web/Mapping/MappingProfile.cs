using AutoMapper;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Web.Models;

namespace PhatHanhSach.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DaiLy,DaiLyViewModel>();
        }
    }
}