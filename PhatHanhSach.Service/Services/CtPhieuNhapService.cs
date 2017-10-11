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
    public interface ICtPhieuNhapService
    {
        CtPhieuNhap Add(CtPhieuNhap ctPhieuNhap);

        void Update(CtPhieuNhap ctPhieuNhap);

        CtPhieuNhap Delete(CtPhieuNhap ctPhieuNhap);

        IEnumerable<CtPhieuNhap> GetAll();

        CtPhieuNhap GetByCode(string code);

        void Save();
    }

    public class CtPhieuNhapService : ICtPhieuNhapService
    {
        private ICtPhieuNhapRepository ctPhieuNhapRepository;
        private IUnitOfWork unitOfWork;

        public CtPhieuNhapService(ICtPhieuNhapRepository ctPhieuNhapRepository, IUnitOfWork unitOfWork)
        {
            this.ctPhieuNhapRepository = ctPhieuNhapRepository;
            this.unitOfWork = unitOfWork;
        }

        public CtPhieuNhap Add(CtPhieuNhap ctPhieuNhap)
        {
            return ctPhieuNhapRepository.Add(ctPhieuNhap);
        }

        public void Update(CtPhieuNhap ctPhieuNhap)
        {
            ctPhieuNhapRepository.Update(ctPhieuNhap);
        }

        public CtPhieuNhap Delete(CtPhieuNhap ctPhieuNhap)
        {
            return ctPhieuNhapRepository.Delete(ctPhieuNhap);
        }

        public IEnumerable<CtPhieuNhap> GetAll()
        {
            return ctPhieuNhapRepository.GetAll();
        }

        public CtPhieuNhap GetByCode(string code)
        {
            return ctPhieuNhapRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
