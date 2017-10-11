using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
