using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtBaoCaoDLRepository : IRepository<CtBaoCaoDL>
    {
    }

    public class CtBaoCaoDLRepository : RepositoryBase<CtBaoCaoDL>, ICtBaoCaoDLRepository
    {
        public CtBaoCaoDLRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
