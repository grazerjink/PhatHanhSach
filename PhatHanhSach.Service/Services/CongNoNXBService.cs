using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ICongNoNXBService
    {
        CongNoNXB Add(CongNoNXB congNoNXB);

        void Update(CongNoNXB congNoNXB);

        CongNoNXB Delete(CongNoNXB congNoNXB);

        IEnumerable<CongNoNXB> GetAll();

        CongNoNXB GetById(int id);

        void Save();
    }

    public class CongNoNXBService : ICongNoNXBService
    {
        private ICongNoNXBRepository congNoNXBRepository;
        private IUnitOfWork unitOfWork;

        public CongNoNXBService(ICongNoNXBRepository congNoNXBRepository, IUnitOfWork unitOfWork)
        {
            this.congNoNXBRepository = congNoNXBRepository;
            this.unitOfWork = unitOfWork;
        }

        public CongNoNXB Add(CongNoNXB congNoNXB)
        {
            return congNoNXBRepository.Add(congNoNXB);
        }

        public void Update(CongNoNXB congNoNXB)
        {
            congNoNXBRepository.Update(congNoNXB);
        }

        public CongNoNXB Delete(CongNoNXB congNoNXB)
        {
            return congNoNXBRepository.Delete(congNoNXB);
        }

        public IEnumerable<CongNoNXB> GetAll()
        {
            return congNoNXBRepository.GetAll();
        }

        public CongNoNXB GetById(int id)
        {
            return congNoNXBRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}