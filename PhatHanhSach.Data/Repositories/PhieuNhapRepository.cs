using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface IPhieuNhapRepository : IRepository<PhieuNhap>
    {
    }

    public class PhieuNhapRepository : RepositoryBase<PhieuNhap>, IPhieuNhapRepository
    {
        public PhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
