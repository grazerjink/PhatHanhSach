using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface IThanhToanService
    {
        ThanhToan Add(ThanhToan thanhToan);

        void Update(ThanhToan thanhToan);

        ThanhToan Delete(ThanhToan thanhToan);

        IEnumerable<ThanhToan> GetAll(string[] includes = null);

        ThanhToan GetById(int id);

        List<ThongKeBaoCaoNXBViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate);

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

        public IEnumerable<ThanhToan> GetAll(string[] includes = null)
        {
            return thanhToanRepository.GetAll(includes);
        }

        public ThanhToan GetById(int id)
        {
            return thanhToanRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public List<ThongKeBaoCaoNXBViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            return thanhToanRepository.GetListAnalysisReport(id, fromDate, toDate);
        }
    }
}