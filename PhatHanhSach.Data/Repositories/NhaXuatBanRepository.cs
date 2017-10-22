using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhatHanhSach.Data.Repositories
{
    public interface INhaXuatBanRepository : IRepository<NhaXuatBan>
    {
    }

    public class NhaXuatBanRepository : RepositoryBase<NhaXuatBan>, INhaXuatBanRepository
    {
        public NhaXuatBanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
