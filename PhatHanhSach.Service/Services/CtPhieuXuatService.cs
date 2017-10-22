using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ICtPhieuXuatService
    {
        CtPhieuXuat Add(CtPhieuXuat ctPhieuXuat);

        void Update(CtPhieuXuat ctPhieuXuat);

        CtPhieuXuat Delete(CtPhieuXuat ctPhieuXuat);

        IEnumerable<CtPhieuXuat> GetAll();

        IEnumerable<CtPhieuXuat> GetMultiByIdPhieuXuat(int idPhieuXuat);

        CtPhieuXuat GetById(int id);

        void Save();
    }

    public class CtPhieuXuatService : ICtPhieuXuatService
    {
        private ICtPhieuXuatRepository ctPhieuXuatRepository;
        private IUnitOfWork unitOfWork;

        public CtPhieuXuatService(ICtPhieuXuatRepository ctPhieuXuatRepository, IUnitOfWork unitOfWork)
        {
            this.ctPhieuXuatRepository = ctPhieuXuatRepository;
            this.unitOfWork = unitOfWork;
        }

        public CtPhieuXuat Add(CtPhieuXuat ctPhieuXuat)
        {
            return ctPhieuXuatRepository.Add(ctPhieuXuat);
        }

        public void Update(CtPhieuXuat ctPhieuXuat)
        {
            ctPhieuXuatRepository.Update(ctPhieuXuat);
        }

        public CtPhieuXuat Delete(CtPhieuXuat ctPhieuXuat)
        {
            return ctPhieuXuatRepository.Delete(ctPhieuXuat);
        }

        public IEnumerable<CtPhieuXuat> GetAll()
        {
            return ctPhieuXuatRepository.GetAll();
        }

        public IEnumerable<CtPhieuXuat> GetMultiByIdPhieuXuat(int idPhieuXuat)
        {
            return ctPhieuXuatRepository.GetMulti(x => x.IdPhieuXuat == idPhieuXuat);
        }

        public CtPhieuXuat GetById(int id)
        {
            return ctPhieuXuatRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}