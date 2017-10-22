using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;

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

        List<ThongKeBaoCaoViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate);

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

        public List<ThongKeBaoCaoViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            return baoCaoDLRepository.GetListAnalysisReport(id, fromDate, toDate);
        }
    }
}