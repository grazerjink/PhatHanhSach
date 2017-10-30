using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IDoanhThuRepository : IRepository<DoanhThu>
    {
        List<ThongKeDoanhThuViewModel> GetListRevenueStatistic(DateTime startDate, DateTime endDate);
    }

    public class DoanhThuRepository : RepositoryBase<DoanhThu>, IDoanhThuRepository
    {
        public DoanhThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<ThongKeDoanhThuViewModel> GetListRevenueStatistic(DateTime startDate, DateTime endDate)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@batDau", startDate),
                new SqlParameter("@ketThuc", endDate)
            };
            return DbContext.Database.SqlQuery<ThongKeDoanhThuViewModel>("proThongKeDoanhThu @batDau, @ketThuc", param).ToListAsync().Result;
        }
    }
}