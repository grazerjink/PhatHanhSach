using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtDoanhThuRepository : IRepository<CtDoanhThu>
    {
    }

    public class CtDoanhThuRepository : RepositoryBase<CtDoanhThu>, ICtDoanhThuRepository
    {
        public CtDoanhThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
