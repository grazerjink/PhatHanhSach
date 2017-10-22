using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface INhaXuatBanService
    {
        NhaXuatBan Add(NhaXuatBan nhaXuatBan);

        void Update(NhaXuatBan nhaXuatBan);

        NhaXuatBan Delete(NhaXuatBan nhaXuatBan);

        IEnumerable<NhaXuatBan> GetAll();

        NhaXuatBan GetById(int id);

        void Save();
    }

    public class NhaXuatBanService : INhaXuatBanService
    {
        private INhaXuatBanRepository nhaXuatBanRepository;
        private IUnitOfWork unitOfWork;

        public NhaXuatBanService(INhaXuatBanRepository nhaXuatBanRepository, IUnitOfWork unitOfWork)
        {
            this.nhaXuatBanRepository = nhaXuatBanRepository;
            this.unitOfWork = unitOfWork;
        }

        public NhaXuatBan Add(NhaXuatBan nhaXuatBan)
        {
            return nhaXuatBanRepository.Add(nhaXuatBan);
        }

        public void Update(NhaXuatBan nhaXuatBan)
        {
            nhaXuatBanRepository.Update(nhaXuatBan);
        }

        public NhaXuatBan Delete(NhaXuatBan nhaXuatBan)
        {
            return nhaXuatBanRepository.Delete(nhaXuatBan);
        }

        public IEnumerable<NhaXuatBan> GetAll()
        {
            return nhaXuatBanRepository.GetAll();
        }

        public NhaXuatBan GetById(int id)
        {
            return nhaXuatBanRepository.GetSingleById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}