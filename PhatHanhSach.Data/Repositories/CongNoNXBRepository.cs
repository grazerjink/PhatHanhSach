using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICongNoNXBRepository : IRepository<CongNoNXB>
    {
    }

    public class CongNoNXBRepository : RepositoryBase<CongNoNXB>, ICongNoNXBRepository
    {
        public CongNoNXBRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
