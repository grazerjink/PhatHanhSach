using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhatHanhSach.Service
{
    public interface IBaoCaoDLService
    {
        BaoCaoDL Add(BaoCaoDL baoCaoDL);

        void Update(BaoCaoDL baoCaoDL);

        BaoCaoDL Delete(BaoCaoDL baoCaoDL);

        IEnumerable<BaoCaoDL> GetAll(string[] includes);

        BaoCaoDL GetById(int id);

        BaoCaoDL GetByCodeHasIncluded(int id, string[] includes);

        List<ThongKeBaoCaoDaiLyViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate);

        bool CheckReportIsCreated(int idDaiLy, DateTime currentCreateDate);

        void Save();
    }

    public class BaoCaoDLService : IBaoCaoDLService
    {
        private IBaoCaoDLRepository baoCaoDLRepository;
        private IUnitOfWork unitOfWork;

        public BaoCaoDLService(IBaoCaoDLRepository baoCaoDLRepository, IUnitOfWork unitOfWork)
        {
            this.baoCaoDLRepository = baoCaoDLRepository;
            this.unitOfWork = unitOfWork;
        }

        public BaoCaoDL Add(BaoCaoDL baoCaoDL)
        {
            return baoCaoDLRepository.Add(baoCaoDL);
        }

        public void Update(BaoCaoDL baoCaoDL)
        {
            baoCaoDLRepository.Update(baoCaoDL);
        }

        public BaoCaoDL Delete(BaoCaoDL baoCaoDL)
        {
            return baoCaoDLRepository.Delete(baoCaoDL);
        }

        public IEnumerable<BaoCaoDL> GetAll(string[] includes)
        {
            if (includes != null)
            {
                return baoCaoDLRepository.GetAll(includes);
            }
            else
            {
                return baoCaoDLRepository.GetAll();
            }
        }

        public BaoCaoDL GetById(int id)
        {
            return baoCaoDLRepository.GetSingleById(id);
        }

        public BaoCaoDL GetByCodeHasIncluded(int id, string[] includes)
        {
            return baoCaoDLRepository.GetSingleByCondition(x => x.Id == id, includes);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public bool CheckReportIsCreated(int idDaiLy, DateTime currentCreateDate)
        {
            var dsBaoCaoDaTao = baoCaoDLRepository.GetMulti(x => x.NgayKetThuc >= currentCreateDate && x.IdDaiLy == idDaiLy && (x.IdTinhTrang == 1 || x.IdTinhTrang == 2)).ToList();
            if (dsBaoCaoDaTao.Count != 0) return true; // Report has created before.
            return false;
        }

        public List<ThongKeBaoCaoDaiLyViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            var listThongKe = new List<ThongKeBaoCaoDaiLyViewModel>();
            var newMonthList = baoCaoDLRepository.GetListAnalysisReport(id, fromDate, toDate);
            var oldMonthExistList = baoCaoDLRepository.GetListExistAtLastMonth(id, fromDate);
            newMonthList.ForEach(n =>
            {
                var newThongKeDL = new ThongKeBaoCaoDaiLyViewModel();
                newThongKeDL.Id = n.Id;
                newThongKeDL.TenSach = n.TenSach;
                newThongKeDL.SoLuongNhap = n.SoLuongTon;
                if (oldMonthExistList.Count > 0)
                {
                    var existItem = oldMonthExistList.Find(y => y.Id == n.Id);
                    if (existItem != null)
                    {
                        newThongKeDL.SoLuongTonDotTruoc = existItem.SoLuongTon;
                    }
                }
                listThongKe.Add(newThongKeDL);
            });

            return listThongKe;
        }
    }
}