using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface ICtBaoCaoDLService
    {
        CtBaoCaoDL Add(CtBaoCaoDL ctBaoCaoDL);

        void Update(CtBaoCaoDL ctBaoCaoDL);

        CtBaoCaoDL Delete(CtBaoCaoDL ctBaoCaoDL);

        IEnumerable<CtBaoCaoDL> GetAll();

        IEnumerable<CtBaoCaoDL> GetMultiById(int idBaoCao, string[] includes = null);

        CtBaoCaoDL GetById(int id);

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

        public CtBaoCaoDL Add(CtBaoCaoDL ctBaoCaoDL)
        {
            return ctBaoCaoDLRepository.Add(ctBaoCaoDL);
        }

        public void Update(CtBaoCaoDL ctBaoCaoDL)
        {
            ctBaoCaoDLRepository.Update(ctBaoCaoDL);
        }

        public CtBaoCaoDL Delete(CtBaoCaoDL ctBaoCaoDL)
        {
            return ctBaoCaoDLRepository.Delete(ctBaoCaoDL);
        }

        public IEnumerable<CtBaoCaoDL> GetAll()
        {
            return ctBaoCaoDLRepository.GetAll();
        }

        public IEnumerable<CtBaoCaoDL> GetMultiById(int idBaoCao, string[] includes = null)
        {
            return ctBaoCaoDLRepository.GetMulti(x => x.IdBaoCao == idBaoCao, includes);
        }

        public CtBaoCaoDL GetById(int id)
        {
            return ctBaoCaoDLRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}