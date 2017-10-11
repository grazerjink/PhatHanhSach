using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Data.Repositories
{
    public interface IThanhToanRepository : IRepository<ThanhToan>
    {
    }

    public class ThanhToanRepository : RepositoryBase<ThanhToan>, IThanhToanRepository
    {
        public ThanhToanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
