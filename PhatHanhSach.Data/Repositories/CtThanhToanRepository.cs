using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtThanhToanRepository : IRepository<CtThanhToan>
    {
    }

    public class CtThanhToanRepository : RepositoryBase<CtThanhToan>, ICtThanhToanRepository
    {
        public CtThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
