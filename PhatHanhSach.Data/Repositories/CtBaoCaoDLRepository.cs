using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtBaoCaoDLRepository : IRepository<CtBaoCaoDL>
    {
    }

    public class CtBaoCaoDLRepository : RepositoryBase<CtBaoCaoDL>, ICtBaoCaoDLRepository
    {
        public CtBaoCaoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
