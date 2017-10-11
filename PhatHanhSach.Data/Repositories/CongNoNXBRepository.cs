using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
