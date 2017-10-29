using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IThanhToanRepository : IRepository<ThanhToan>
    {
        List<ThongKeSachNhapViewModel> GetListImported(int id, DateTime fromDate, DateTime toDate);
        List<ThongKeSachXuatViewModel> GetListExported(int id, DateTime fromDate, DateTime toDate);
        List<ThongKeBaoCaoViewModel> GetListExistAtLastMonth(int id, DateTime newCreateDate);
    }

    public class ThanhToanRepository : RepositoryBase<ThanhToan>, IThanhToanRepository
    {
        public ThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<ThongKeSachNhapViewModel> GetListImported(int id, DateTime fromDate, DateTime toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maNXB",id),
                new SqlParameter("@batDau",fromDate),
                new SqlParameter("@ketThuc",toDate)
            };
            return DbContext.Database.SqlQuery<ThongKeSachNhapViewModel>("proThongKeSachNhap @maNXB, @batDau, @ketThuc", parameters).ToListAsync().Result;
        }

        public List<ThongKeSachXuatViewModel> GetListExported(int id, DateTime fromDate, DateTime toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maNXB",id),
                new SqlParameter("@batDau",fromDate),
                new SqlParameter("@ketThuc",toDate)
            };
            return DbContext.Database.SqlQuery<ThongKeSachXuatViewModel>("proThongKeSachXuat @maNXB, @batDau, @ketThuc", parameters).ToListAsync().Result;
        }

        public List<ThongKeBaoCaoViewModel> GetListExistAtLastMonth(int id, DateTime newCreateDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maNXB",id),
                new SqlParameter("@ngayTaoMoi",newCreateDate)
            };
            return DbContext.Database.SqlQuery<ThongKeBaoCaoViewModel>("proThongKeSLTonThangTruoc @maNXB, @ngayTaoMoi", parameters).ToListAsync().Result;
        }
    }
}