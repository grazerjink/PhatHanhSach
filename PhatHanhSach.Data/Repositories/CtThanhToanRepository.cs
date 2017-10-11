using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Data.Repositories
{
    public interface ICtThanhToanRepository : IRepository<CtThanhToan>
    {
    }

    public class CtThanhToanRepository : RepositoryBase<CtThanhToan>, ICtThanhToanRepository
    {
        public CtThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
