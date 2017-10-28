using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ICtThanhToanService
    {
        CtThanhToan Add(CtThanhToan ctThanhToan);

        void Update(CtThanhToan ctThanhToan);

        CtThanhToan Delete(CtThanhToan ctThanhToan);

        IEnumerable<CtThanhToan> GetAll();

        CtThanhToan GetById(int id);

        IEnumerable<CtThanhToan> GetMultiById(int idThanhToan, string[] includes = null);

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

        public CtThanhToan GetById(int id)
        {
            return ctThanhToanRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<CtThanhToan> GetMultiById(int idThanhToan, string[] includes = null)
        {
            return ctThanhToanRepository.GetMulti(x => x.IdThanhToan == idThanhToan, includes);
        }
    }
}