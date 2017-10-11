using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Service
{
    public interface ICongNoNXBService
    {
        CongNoNXB Add(CongNoNXB congNoNXB);

        void Update(CongNoNXB congNoNXB);

        CongNoNXB Delete(CongNoNXB congNoNXB);

        IEnumerable<CongNoNXB> GetAll();

        CongNoNXB GetByCode(string code);

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

        public CongNoNXB GetByCode(string code)
        {
            return congNoNXBRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
