
using PhatHanhSach.Data.Models;

namespace PhatHanhSach.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private PhatHanhSachEntities entities;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public PhatHanhSachEntities DbContext
        {
            get { return entities ?? (entities = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
