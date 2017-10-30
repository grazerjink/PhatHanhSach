using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;

namespace PhatHanhSach.Data.Repositories
{
    public interface ITonKhoRepository : IRepository<TonKho>
    {
    }

    public class TonKhoRepository : RepositoryBase<TonKho>, ITonKhoRepository
    {
        public TonKhoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}