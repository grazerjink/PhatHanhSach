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
    public interface ICtBaoCaoDLService
    {
        CtBaoCaoDL Add(CtBaoCaoDL ctBaoCaoDL);

        void Update(CtBaoCaoDL ctBaoCaoDL);

        CtBaoCaoDL Delete(CtBaoCaoDL ctBaoCaoDL);

        IEnumerable<CtBaoCaoDL> GetAll();

        CtBaoCaoDL GetByCode(string code);

        void Save();
    }

    public class CtBaoCaoDLService : ICtBaoCaoDLService
    {
        private ICtBaoCaoDLRepository ctBaoCaoDLRepository;
        private IUnitOfWork unitOfWork;

        public CtBaoCaoDLService(ICtBaoCaoDLRepository ctBaoCaoDLRepository, IUnitOfWork unitOfWork)
        {
            this.ctBaoCaoDLRepository = ctBaoCaoDLRepository;
            this.unitOfWork = unitOfWork;
        }

        public CtBaoCaoDL  Add(CtBaoCaoDL ctBaoCaoDL)
        {
            return ctBaoCaoDLRepository.Add(ctBaoCaoDL);
        }

        public void Update(CtBaoCaoDL ctBaoCaoDL)
        {
            ctBaoCaoDLRepository.Update(ctBaoCaoDL);
        }

        public CtBaoCaoDL  Delete(CtBaoCaoDL ctBaoCaoDL)
        {
            return ctBaoCaoDLRepository.Delete(ctBaoCaoDL);
        }

        public IEnumerable<CtBaoCaoDL> GetAll()
        {
            return ctBaoCaoDLRepository.GetAll();
        }

        public CtBaoCaoDL GetByCode(string code)
        {
            return ctBaoCaoDLRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
