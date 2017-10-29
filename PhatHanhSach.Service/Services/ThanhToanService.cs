using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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

        bool CheckReportIsCreated(int idNXB, DateTime currentCreateDate);
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
            var listImported = thanhToanRepository.GetListImported(id, fromDate, toDate);
            var listExported = thanhToanRepository.GetListExported(id, fromDate, toDate);

            var newMonthList = new List<ThongKeBaoCaoNXBViewModel>();
            if (listExported.Count > 0)
            {
                listImported.ForEach(x =>
                {
                    var baoCaoNXB = new ThongKeBaoCaoNXBViewModel();
                    baoCaoNXB.Id = x.Id;
                    baoCaoNXB.SoLuongNhap = x.SoLuongNhap;
                    baoCaoNXB.DonGiaNhap = x.DonGiaNhap;
                    baoCaoNXB.TongTienNhap = x.SoLuongNhap * x.DonGiaNhap;

                    var existItem = listExported.Find(y => y.Id == x.Id);
                    if(existItem != null)
                    {
                        baoCaoNXB.SoLuongXuat = existItem.SoLuongXuat;
                        baoCaoNXB.TongTienThanhToan = existItem.DonGiaNhap * existItem.SoLuongXuat;
                        baoCaoNXB.TongTienNo = x.TongTienNhap - existItem.TongTienXuat;
                    }
                    else
                    {
                        baoCaoNXB.SoLuongXuat = 0;
                        baoCaoNXB.TongTienThanhToan = 0;
                        baoCaoNXB.TongTienNo = x.TongTienNhap;
                    }
                    newMonthList.Add(baoCaoNXB);
                });
            }

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

        public bool CheckReportIsCreated(int idNXB, DateTime currentCreateDate)
        {
            var dsBaoCaoDaTao = thanhToanRepository.GetMulti(x => x.NgayKetThuc >= currentCreateDate && x.IdNXB == idNXB && (x.IdTinhTrang == 1 || x.IdTinhTrang == 2)).ToList();
            if (dsBaoCaoDaTao.Count != 0) return true; // Report has created before.
            return false;
        }
    }
}