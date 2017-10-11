using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Repositories
{
    public interface IDaiLyRepository : IRepository<DaiLy>
    {
    }

    public class DaiLyRepository : RepositoryBase<DaiLy>, IDaiLyRepository
    {
        public DaiLyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
