using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
