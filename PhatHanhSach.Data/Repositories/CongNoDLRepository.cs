using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICongNoDLRepository : IRepository<CongNoDL>
    {
    }

    public class CongNoDLRepository : RepositoryBase<CongNoDL>, ICongNoDLRepository
    {
        public CongNoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
