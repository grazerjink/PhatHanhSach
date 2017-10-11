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
    public interface IBaoCaoDLService
    {
        BaoCaoDL Add(BaoCaoDL baoCaoDL);

        void Update(BaoCaoDL baoCaoDL);

        BaoCaoDL Delete(BaoCaoDL baoCaoDL);

        IEnumerable<BaoCaoDL> GetAll();

        BaoCaoDL GetByCode(string code);

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

        public IEnumerable<BaoCaoDL> GetAll()
        {
            return baoCaoDLRepository.GetAll();
        }

        public BaoCaoDL GetByCode(string code)
        {
            return baoCaoDLRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
