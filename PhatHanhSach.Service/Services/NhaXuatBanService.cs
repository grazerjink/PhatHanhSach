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
    public interface INhaXuatBanService
    {
        NhaXuatBan Add(NhaXuatBan nhaXuatBan);

        void Update(NhaXuatBan nhaXuatBan);

        NhaXuatBan Delete(NhaXuatBan nhaXuatBan);

        IEnumerable<NhaXuatBan> GetAll();

        NhaXuatBan GetByCode(string code);

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

        public NhaXuatBan GetByCode(string code)
        {
            return nhaXuatBanRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
