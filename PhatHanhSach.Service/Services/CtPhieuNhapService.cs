using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ICtPhieuNhapService
    {
        CtPhieuNhap Add(CtPhieuNhap ctPhieuNhap);

        void Update(CtPhieuNhap ctPhieuNhap);

        CtPhieuNhap Delete(CtPhieuNhap ctPhieuNhap);

        IEnumerable<CtPhieuNhap> GetAll();

        IEnumerable<CtPhieuNhap> GetMultiByIdPhieuNhap(int idPhieuNhap, string[] includes = null);

        CtPhieuNhap GetById(int id);

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

        public IEnumerable<CtPhieuNhap> GetMultiByIdPhieuNhap(int idPhieuNhap, string[] includes = null)
        {
            return ctPhieuNhapRepository.GetMulti(x => x.IdPhieuNhap == idPhieuNhap, includes);
        }

        public CtPhieuNhap GetById(int id)
        {
            return ctPhieuNhapRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}