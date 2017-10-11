using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Repositories
{
    public interface INhaXuatBanRepository : IRepository<NhaXuatBan>
    {
    }

    public class NhaXuatBanRepository : RepositoryBase<NhaXuatBan>, INhaXuatBanRepository
    {
        public NhaXuatBanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
