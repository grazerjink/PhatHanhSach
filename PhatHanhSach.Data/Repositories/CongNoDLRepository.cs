using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Model;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICongNoDLRepository : IRepository<CongNoDL>
    {
    }

    public class CongNoDLRepository : RepositoryBase<CongNoDL>, ICongNoDLRepository
    {
        public CongNoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}