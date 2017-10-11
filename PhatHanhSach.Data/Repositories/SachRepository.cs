using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Repositories
{
    public interface ISachRepository : IRepository<Sach>
    {
    }

    public class SachRepository : RepositoryBase<Sach>, ISachRepository
    {
        public SachRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
