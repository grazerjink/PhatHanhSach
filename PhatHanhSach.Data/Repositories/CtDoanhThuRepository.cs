using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtDoanhThuRepository : IRepository<CtDoanhThu>
    {
    }

    public class CtDoanhThuRepository : RepositoryBase<CtDoanhThu>, ICtDoanhThuRepository
    {
        public CtDoanhThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
