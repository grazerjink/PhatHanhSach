using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtPhieuXuatRepository : IRepository<CtPhieuXuat>
    {
    }

    public class CtPhieuXuatRepository : RepositoryBase<CtPhieuXuat>, ICtPhieuXuatRepository
    {
        public CtPhieuXuatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
