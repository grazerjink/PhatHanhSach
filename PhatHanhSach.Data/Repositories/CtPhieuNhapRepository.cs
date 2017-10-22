using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtPhieuNhapRepository : IRepository<CtPhieuNhap>
    {
    }

    public class CtPhieuNhapRepository : RepositoryBase<CtPhieuNhap>, ICtPhieuNhapRepository
    {
        public CtPhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
