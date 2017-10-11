using PhatHanhSach.Data.Models;
using System;

namespace PhatHanhSach.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PhatHanhSachEntities Init();
    }

    public class DbFactory : Disposable, IDbFactory
    {
        private PhatHanhSachEntities dbContext;
        
        public PhatHanhSachEntities Init()
        {
            return dbContext ?? (dbContext = new PhatHanhSachEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
