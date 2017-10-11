using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
