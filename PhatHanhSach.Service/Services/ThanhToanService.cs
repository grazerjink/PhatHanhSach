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

        ThanhToan GetById(int id, string[] includes=null);

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

        public ThanhToan GetById(int id, string[] includes = null)
        {
            return thanhToanRepository.GetSingleByCondition(x => x.Id == id, includes);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public List<ThongKeBaoCaoNXBViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            var newMonthList = thanhToanRepository.GetListAnalysisReport(id, fromDate, toDate);
            var oldMonthExistList = thanhToanRepository.GetListExistAtLastMonth(id, fromDate);
            if (oldMonthExistList.Count > 0)
            {
                newMonthList.ForEach(x =>
                {
                    var existItem = oldMonthExistList.Find(y => y.Id == x.Id);
                    if (existItem != null)
                        x.SoLuongNhap += existItem.SoLuongMua;
                });
            }
            return newMonthList;
        }
    }
}