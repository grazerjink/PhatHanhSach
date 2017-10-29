using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface IPhieuXuatService
    {
        PhieuXuat Add(PhieuXuat phieuXuat);

        void Update(PhieuXuat phieuXuat);

        PhieuXuat Delete(PhieuXuat phieuXuat);

        IEnumerable<PhieuXuat> GetAll(string[] includes);

        PhieuXuat GetById(int id);

        IEnumerable<PhieuXuat> GetAllByRangeDate(DateTime startDate, DateTime endDate);

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

        public PhieuXuat GetById(int id)
        {
            return phieuXuatRepository.GetSingleById(id);
        }

        public IEnumerable<PhieuXuat> GetAllByRangeDate(DateTime startDate, DateTime endDate)
        {
            return phieuXuatRepository.GetMulti(x => x.ThoiGianXuat >= startDate && x.ThoiGianXuat <= endDate);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}