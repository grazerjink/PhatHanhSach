using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IDaiLyRepository : IRepository<DaiLy>
    {
    }

    public class DaiLyRepository : RepositoryBase<DaiLy>, IDaiLyRepository
    {
        public DaiLyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
