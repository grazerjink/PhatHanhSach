using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtPhieuNhapRepository : IRepository<CtPhieuXuat>
    {
    }

    public class CtPhieuNhapRepository : RepositoryBase<CtPhieuXuat>, ICtPhieuNhapRepository
    {
        public CtPhieuNhapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
