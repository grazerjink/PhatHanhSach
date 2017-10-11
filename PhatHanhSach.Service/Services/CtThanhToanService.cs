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
    public interface ICtThanhToanService
    {
        CtThanhToan Add(CtThanhToan ctThanhToan);

        void Update(CtThanhToan ctThanhToan);

        CtThanhToan Delete(CtThanhToan ctThanhToan);

        IEnumerable<CtThanhToan> GetAll();

        CtThanhToan GetByCode(string code);

        void Save();
    }

    public class CtThanhToanService : ICtThanhToanService
    {
        private ICtThanhToanRepository ctThanhToanRepository;
        private IUnitOfWork unitOfWork;

        public CtThanhToanService(ICtThanhToanRepository ctThanhToanRepository, IUnitOfWork unitOfWork)
        {
            this.ctThanhToanRepository = ctThanhToanRepository;
            this.unitOfWork = unitOfWork;
        }

        public CtThanhToan Add(CtThanhToan ctThanhToan)
        {
            return ctThanhToanRepository.Add(ctThanhToan);
        }

        public void Update(CtThanhToan ctThanhToan)
        {
            ctThanhToanRepository.Update(ctThanhToan);
        }

        public CtThanhToan Delete(CtThanhToan ctThanhToan)
        {
            return ctThanhToanRepository.Delete(ctThanhToan);
        }

        public IEnumerable<CtThanhToan> GetAll()
        {
            return ctThanhToanRepository.GetAll();
        }

        public CtThanhToan GetByCode(string code)
        {
            return ctThanhToanRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
