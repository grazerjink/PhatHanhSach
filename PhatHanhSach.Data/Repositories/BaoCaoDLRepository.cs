using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Repositories
{
    public interface IBaoCaoDLRepository : IRepository<BaoCaoDL>
    {
    }

    public class BaoCaoDLRepository : RepositoryBase<BaoCaoDL>, IBaoCaoDLRepository
    {
        public BaoCaoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
