using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ITinhTrangRepository : IRepository<TinhTrang>
    {
    }

    public class TinhTrangRepository : RepositoryBase<TinhTrang>, ITinhTrangRepository
    {
        public TinhTrangRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {
        }
    }
}
