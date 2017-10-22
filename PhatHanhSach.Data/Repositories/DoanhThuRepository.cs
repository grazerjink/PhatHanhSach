using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IDoanhThuRepository : IRepository<DoanhThu>
    {
    }

    public class DoanhThuRepository : RepositoryBase<DoanhThu>, IDoanhThuRepository
    {
        public DoanhThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
