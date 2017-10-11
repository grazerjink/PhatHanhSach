using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

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
