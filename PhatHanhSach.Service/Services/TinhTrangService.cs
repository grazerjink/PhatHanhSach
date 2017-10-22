using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service.Services
{
    public interface ITinhTrangService
    {
        TinhTrang Add(TinhTrang tinhTrang);

        void Update(TinhTrang tinhTrang);

        TinhTrang Delete(TinhTrang tinhTrang);

        IEnumerable<TinhTrang> GetAll();

        void Save();
    }

    internal class TinhTrangService : ITinhTrangService
    {
        private ITinhTrangRepository tinhTrangRepository;
        private IUnitOfWork unitOfWork;

        public TinhTrangService(ITinhTrangRepository tinhTrangRepository, IUnitOfWork unitOfWork)
        {
            this.tinhTrangRepository = tinhTrangRepository;
            this.unitOfWork = unitOfWork;
        }

        public TinhTrang Add(TinhTrang tinhTrang)
        {
            return tinhTrangRepository.Add(tinhTrang);
        }

        public TinhTrang Delete(TinhTrang tinhTrang)
        {
            return tinhTrangRepository.Delete(tinhTrang);
        }

        public IEnumerable<TinhTrang> GetAll()
        {
            return tinhTrangRepository.GetAll();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(TinhTrang tinhTrang)
        {
            tinhTrangRepository.Update(tinhTrang);
        }
    }
}