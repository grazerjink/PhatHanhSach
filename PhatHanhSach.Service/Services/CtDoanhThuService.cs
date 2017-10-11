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
    public interface ICtDoanhThuService
    {
        CtDoanhThu Add(CtDoanhThu ctDoanhThu);

        void Update(CtDoanhThu ctDoanhThu);

        CtDoanhThu Delete(CtDoanhThu ctDoanhThu);

        IEnumerable<CtDoanhThu> GetAll();

        CtDoanhThu GetByCode(string code);

        void Save();
    }

    public class CtDoanhThuService : ICtDoanhThuService
    {
        private ICtDoanhThuRepository ctDoanhThuRepository;
        private IUnitOfWork unitOfWork;

        public CtDoanhThuService(ICtDoanhThuRepository ctDoanhThuRepository, IUnitOfWork unitOfWork)
        {
            this.ctDoanhThuRepository = ctDoanhThuRepository;
            this.unitOfWork = unitOfWork;
        }

        public CtDoanhThu Add(CtDoanhThu ctDoanhThu)
        {
            return ctDoanhThuRepository.Add(ctDoanhThu);
        }

        public void Update(CtDoanhThu ctDoanhThu)
        {
            ctDoanhThuRepository.Update(ctDoanhThu);
        }

        public CtDoanhThu Delete(CtDoanhThu ctDoanhThu)
        {
            return ctDoanhThuRepository.Delete(ctDoanhThu);
        }

        public IEnumerable<CtDoanhThu> GetAll()
        {
            return ctDoanhThuRepository.GetAll();
        }

        public CtDoanhThu GetByCode(string code)
        {
            return ctDoanhThuRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
