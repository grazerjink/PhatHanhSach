using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IThanhToanRepository : IRepository<ThanhToan>
    {
    }

    public class ThanhToanRepository : RepositoryBase<ThanhToan>, IThanhToanRepository
    {
        public ThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
