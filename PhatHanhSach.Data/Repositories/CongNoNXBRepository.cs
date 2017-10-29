using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICongNoNXBRepository : IRepository<CongNoNXB>
    {
    }

    public class CongNoNXBRepository : RepositoryBase<CongNoNXB>, ICongNoNXBRepository
    {
        public CongNoNXBRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}