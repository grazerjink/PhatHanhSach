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
        List<ThongKeBaoCaoNXBViewModel> GetListImportedAndExported(int id, DateTime fromDate, DateTime toDate);
        List<ThongKeBaoCaoViewModel> GetListExistAtLastMonth(int id, DateTime newCreateDate);
    }

    public class ThanhToanRepository : RepositoryBase<ThanhToan>, IThanhToanRepository
    {        
        public ThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public List<ThongKeBaoCaoNXBViewModel> GetListImportedAndExported(int id, DateTime fromDate, DateTime toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maNXB",id),
                new SqlParameter("@batDau",fromDate),
                new SqlParameter("@ketThuc",toDate)
            };
            return DbContext.Database.SqlQuery<ThongKeBaoCaoNXBViewModel>("proThongKeTienSachTraNXB @maNXB, @batDau, @ketThuc", parameters).ToListAsync().Result;
        }

        public List<ThongKeBaoCaoViewModel> GetListExistAtLastMonth(int id, DateTime newCreateDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maNXB",id),
                new SqlParameter("@ngayTaoMoi",newCreateDate)
            };
            return DbContext.Database.SqlQuery<ThongKeBaoCaoViewModel>("proThongKeSLTonThangTruocTheoNXB @maNXB, @ngayTaoMoi", parameters).ToListAsync().Result;
        }
    }
}