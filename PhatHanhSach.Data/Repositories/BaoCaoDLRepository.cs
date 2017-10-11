using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Repositories
{
    public interface IBaoCaoDLRepository : IRepository<CtThanhToan>
    {
    }

    public class BaoCaoDLRepository : RepositoryBase<CtThanhToan>, IBaoCaoDLRepository
    {
        public BaoCaoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
