using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Models;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHanhSach.Service
{
    public interface IBaoCaoDLService
    {
        BaoCaoDL Add(BaoCaoDL baoCaoDL);

        void Update(BaoCaoDL baoCaoDL);

        BaoCaoDL Delete(BaoCaoDL baoCaoDL);

        IEnumerable<BaoCaoDL> GetAll(string[] includes);

        BaoCaoDL GetByCode(string code);

        List<ThongKeBaoCaoViewModel> GetListAnalysisReport(string code, DateTime fromDate, DateTime toDate);

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
            if(includes != null)
            {
                return baoCaoDLRepository.GetAll(includes);
            }
            else
            {
                return baoCaoDLRepository.GetAll();
            }
        }

        public BaoCaoDL GetByCode(string code)
        {
            return baoCaoDLRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public List<ThongKeBaoCaoViewModel> GetListAnalysisReport(string code, DateTime fromDate, DateTime toDate)
        {
            return baoCaoDLRepository.GetListAnalysisReport(code, fromDate, toDate);
        }
    }
}
