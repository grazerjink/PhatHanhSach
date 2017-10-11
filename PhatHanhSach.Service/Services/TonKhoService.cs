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
    public interface ITonKhoService
    {
        TonKho Add(TonKho tonKho);

        void Update(TonKho tonKho);

        TonKho Delete(TonKho tonKho);

        IEnumerable<TonKho> GetAll();

        TonKho GetByCode(string code);

        void Save();
    }

    public class TonKhoService : ITonKhoService
    {
        private ITonKhoRepository tonKhoRepository;
        private IUnitOfWork unitOfWork;

        public TonKhoService(ITonKhoRepository tonKhoRepository, IUnitOfWork unitOfWork)
        {
            this.tonKhoRepository = tonKhoRepository;
            this.unitOfWork = unitOfWork;
        }

        public TonKho Add(TonKho tonKho)
        {
            return tonKhoRepository.Add(tonKho);
        }

        public void Update(TonKho tonKho)
        {
            tonKhoRepository.Update(tonKho);
        }

        public TonKho Delete(TonKho tonKho)
        {
            return tonKhoRepository.Delete(tonKho);
        }

        public IEnumerable<TonKho> GetAll()
        {
            return tonKhoRepository.GetAll();
        }

        public TonKho GetByCode(string code)
        {
            return tonKhoRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
