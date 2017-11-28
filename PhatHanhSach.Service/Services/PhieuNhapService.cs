using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhatHanhSach.Service
{
    public interface IPhieuNhapService
    {
        PhieuNhap Add(PhieuNhap phieuNhap);

        void Update(PhieuNhap phieuNhap);

        PhieuNhap Delete(PhieuNhap phieuNhap);

        IEnumerable<PhieuNhap> GetAll(string[] includes = null, bool trangThai = true);

        PhieuNhap GetById(int id);

        IEnumerable<PhieuNhap> GetAllByRangeDate(DateTime startDate, DateTime endDate);

        void Save();

        DateTime? GetFirstDateToCreateReport(int id);
    }

    public class PhieuNhapService : IPhieuNhapService
    {
        private IPhieuNhapRepository phieuNhapRepository;
        private IUnitOfWork unitOfWork;

        public PhieuNhapService(IPhieuNhapRepository phieuNhapRepository, IUnitOfWork unitOfWork)
        {
            this.phieuNhapRepository = phieuNhapRepository;
            this.unitOfWork = unitOfWork;
        }

        public PhieuNhap Add(PhieuNhap phieuNhap)
        {
            return phieuNhapRepository.Add(phieuNhap);
        }

        public void Update(PhieuNhap phieuNhap)
        {
            phieuNhapRepository.Update(phieuNhap);
        }

        public PhieuNhap Delete(PhieuNhap phieuNhap)
        {
            return phieuNhapRepository.Delete(phieuNhap);
        }

        public IEnumerable<PhieuNhap> GetAll(string[] includes = null, bool trangThai = true)
        {
            if (includes != null)
                return phieuNhapRepository.GetMulti(x => x.TrangThai == trangThai, includes);
            else
                return phieuNhapRepository.GetMulti(x => x.TrangThai == trangThai);
        }

        public PhieuNhap GetById(int id)
        {
            return phieuNhapRepository.GetSingleById(id);
        }

        public IEnumerable<PhieuNhap> GetAllByRangeDate(DateTime startDate, DateTime endDate)
        {
            return phieuNhapRepository.GetMulti(x => x.ThoiGianNhap >= startDate && x.ThoiGianNhap <= endDate);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public DateTime? GetFirstDateToCreateReport(int id)
        {
            var phieuNhapOldest = phieuNhapRepository.GetMulti(x => x.IdNXB == id).OrderBy(x => x.ThoiGianNhap).FirstOrDefault();
            if (phieuNhapOldest != null)
                return phieuNhapOldest.ThoiGianNhap.Value;
            else
                return null;
        }
    }
}