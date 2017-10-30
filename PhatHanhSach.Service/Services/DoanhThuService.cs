using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface IDoanhThuService
    {
        DoanhThu Add(DoanhThu doanhThu);

        void Update(DoanhThu doanhThu);

        DoanhThu Delete(DoanhThu doanhThu);

        List<ThongKeDoanhThuViewModel> GetListRevenueStatistic(DateTime startDate, DateTime endDate);

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

        public List<ThongKeDoanhThuViewModel> GetListRevenueStatistic(DateTime startDate, DateTime endDate)
        {
            return doanhThuRepository.GetListRevenueStatistic(startDate, endDate);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}