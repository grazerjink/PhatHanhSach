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
    public interface IThanhToanService
    {
        ThanhToan Add(ThanhToan thanhToan);

        void Update(ThanhToan thanhToan);

        ThanhToan Delete(ThanhToan thanhToan);

        IEnumerable<ThanhToan> GetAll();

        ThanhToan GetByCode(string code);

        void Save();
    }

    public class ThanhToanService : IThanhToanService
    {
        private IThanhToanRepository thanhToanRepository;
        private IUnitOfWork unitOfWork;

        public ThanhToanService(IThanhToanRepository thanhToanRepository, IUnitOfWork unitOfWork)
        {
            this.thanhToanRepository = thanhToanRepository;
            this.unitOfWork = unitOfWork;
        }

        public ThanhToan Add(ThanhToan thanhToan)
        {
            return thanhToanRepository.Add(thanhToan);
        }

        public void Update(ThanhToan thanhToan)
        {
            thanhToanRepository.Update(thanhToan);
        }

        public ThanhToan Delete(ThanhToan thanhToan)
        {
            return thanhToanRepository.Delete(thanhToan);
        }

        public IEnumerable<ThanhToan> GetAll()
        {
            return thanhToanRepository.GetAll();
        }

        public ThanhToan GetByCode(string code)
        {
            return thanhToanRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
