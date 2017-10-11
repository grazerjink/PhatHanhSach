using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
namespace PhatHanhSach.Data.Repositories
{
    public interface IDoanhThuRepository : IRepository<DoanhThu>
    {
    }

    public class DoanhThuRepository : RepositoryBase<DoanhThu>, IDoanhThuRepository
    {
        public DoanhThuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
