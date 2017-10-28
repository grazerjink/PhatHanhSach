using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtThanhToanRepository : IRepository<CtThanhToan>
    {
    }

    public class CtThanhToanRepository : RepositoryBase<CtThanhToan>, ICtThanhToanRepository
    {
        public CtThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}