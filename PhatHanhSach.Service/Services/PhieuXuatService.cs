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
    public interface IPhieuXuatService
    {
        PhieuXuat Add(PhieuXuat phieuXuat);

        void Update(PhieuXuat phieuXuat);

        PhieuXuat Delete(PhieuXuat phieuXuat);

        IEnumerable<PhieuXuat> GetAll(string[] includes);

        PhieuXuat GetByCode(string code);

        void Save();
    }

    public class PhieuXuatService : IPhieuXuatService
    {
        private IPhieuXuatRepository phieuXuatRepository;
        private IUnitOfWork unitOfWork;

        public PhieuXuatService(IPhieuXuatRepository phieuXuatRepository, IUnitOfWork unitOfWork)
        {
            this.phieuXuatRepository = phieuXuatRepository;
            this.unitOfWork = unitOfWork;
        }

        public PhieuXuat Add(PhieuXuat phieuXuat)
        {
            return phieuXuatRepository.Add(phieuXuat);
        }

        public void Update(PhieuXuat phieuXuat)
        {
            phieuXuatRepository.Update(phieuXuat);
        }

        public PhieuXuat Delete(PhieuXuat phieuXuat)
        {
            return phieuXuatRepository.Delete(phieuXuat);
        }

        public IEnumerable<PhieuXuat> GetAll(string[] includes)
        {
            if (includes != null)
                return phieuXuatRepository.GetAll(includes);
            else
                return phieuXuatRepository.GetAll();
        }

        public PhieuXuat GetByCode(string code)
        {
            return phieuXuatRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
