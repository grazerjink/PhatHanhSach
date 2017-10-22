using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ISachService
    {
        Sach Add(Sach sach);

        void Update(Sach sach);

        Sach Delete(Sach sach);

        IEnumerable<Sach> GetAll();

        Sach GetById(int id);

        void Save();
    }

    public class SachService : ISachService
    {
        private ISachRepository sachRepository;
        private IUnitOfWork unitOfWork;

        public SachService(ISachRepository sachRepository, IUnitOfWork unitOfWork)
        {
            this.sachRepository = sachRepository;
            this.unitOfWork = unitOfWork;
        }

        public Sach Add(Sach sach)
        {
            return sachRepository.Add(sach);
        }

        public void Update(Sach sach)
        {
            sachRepository.Update(sach);
        }

        public Sach Delete(Sach sach)
        {
            return sachRepository.Delete(sach);
        }

        public IEnumerable<Sach> GetAll()
        {
            return sachRepository.GetAll();
        }

        public Sach GetById(int id)
        {
            return sachRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}