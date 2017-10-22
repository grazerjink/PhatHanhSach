using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IPhieuXuatRepository : IRepository<PhieuXuat>
    {
    }

    public class PhieuXuatRepository : RepositoryBase<PhieuXuat>, IPhieuXuatRepository
    {
        public PhieuXuatRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
