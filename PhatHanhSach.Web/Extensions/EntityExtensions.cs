using PhatHanhSach.Data.Models;
using PhatHanhSach.Web.Models;

namespace PhatHanhSach.Web.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDaiLy(this DaiLy daiLy, DaiLyViewModel daiLyVm)
        {
            daiLy.MaDaiLy = daiLyVm.MaDaiLy;
            daiLy.TenDaiLy = daiLyVm.TenDaiLy;
            daiLy.SoDienThoai = daiLyVm.SoDienThoai;
            daiLy.DiaChi = daiLyVm.DiaChi;
            daiLy.TrangThai = daiLyVm.TrangThai;
        }
    }
}