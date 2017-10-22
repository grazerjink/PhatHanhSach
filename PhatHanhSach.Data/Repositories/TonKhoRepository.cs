using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ITonKhoRepository : IRepository<TonKho>
    {
    }

    public class TonKhoRepository : RepositoryBase<TonKho>, ITonKhoRepository
    {
        public TonKhoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
