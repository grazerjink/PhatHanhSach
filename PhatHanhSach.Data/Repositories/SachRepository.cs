using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ISachRepository : IRepository<Sach>
    {
    }

    public class SachRepository : RepositoryBase<Sach>, ISachRepository
    {
        public SachRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
