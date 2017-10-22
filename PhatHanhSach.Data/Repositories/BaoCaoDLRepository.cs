using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IBaoCaoDLRepository : IRepository<BaoCaoDL>
    {
        List<ThongKeBaoCaoViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate);
    }

    public class BaoCaoDLRepository : RepositoryBase<BaoCaoDL>, IBaoCaoDLRepository
    {
        public BaoCaoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<ThongKeBaoCaoViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@maDaiLy",id),
                new SqlParameter("@batDau",fromDate),
                new SqlParameter("@ketThuc",toDate)
            };

            return DbContext.Database.SqlQuery<ThongKeBaoCaoViewModel>("procThongKeBaoCaoDL @maDaiLy, @batDau, @ketThuc",parameters).ToListAsync().Result;
        }
    }
}
