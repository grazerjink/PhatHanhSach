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
    public interface IDoanhThuService
    {
        DoanhThu Add(DoanhThu doanhThu);

        void Update(DoanhThu doanhThu);

        DoanhThu Delete(DoanhThu doanhThu);

        IEnumerable<DoanhThu> GetAll();

        DoanhThu GetByCode(string code);

        void Save();
    }

    public class DoanhThuService : IDoanhThuService
    {
        private IDoanhThuRepository doanhThuRepository;
        private IUnitOfWork unitOfWork;

        public DoanhThuService(IDoanhThuRepository doanhThuRepository, IUnitOfWork unitOfWork)
        {
            this.doanhThuRepository = doanhThuRepository;
            this.unitOfWork = unitOfWork;
        }

        public DoanhThu Add(DoanhThu doanhThu)
        {
            return doanhThuRepository.Add(doanhThu);
        }

        public void Update(DoanhThu doanhThu)
        {
            doanhThuRepository.Update(doanhThu);
        }

        public DoanhThu Delete(DoanhThu doanhThu)
        {
            return doanhThuRepository.Delete(doanhThu);
        }

        public IEnumerable<DoanhThu> GetAll()
        {
            return doanhThuRepository.GetAll();
        }

        public DoanhThu GetByCode(string code)
        {
            return doanhThuRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
