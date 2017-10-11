using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

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
