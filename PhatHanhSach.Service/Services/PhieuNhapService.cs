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
    public interface IPhieuNhapService
    {
        PhieuNhap Add(PhieuNhap phieuNhap);

        void Update(PhieuNhap phieuNhap);

        PhieuNhap Delete(PhieuNhap phieuNhap);

        IEnumerable<PhieuNhap> GetAll();

        PhieuNhap GetByCode(string code);

        void Save();
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

        public IEnumerable<PhieuNhap> GetAll()
        {
            return phieuNhapRepository.GetAll();
        }

        public PhieuNhap GetByCode(string code)
        {
            return phieuNhapRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
