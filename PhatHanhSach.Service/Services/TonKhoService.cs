using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhatHanhSach.Service
{
    public interface ITonKhoService
    {
        TonKho Add(TonKho tonKho);

        void Update(TonKho tonKho);

        TonKho Delete(TonKho tonKho);

        IEnumerable<TonKho> GetAll(string[] includes);

        IEnumerable<TonKho> GetMultiByDateAndId(DateTime date, int idSach);

        TonKho GetSingleByIdAndDate(int idSach, DateTime date);

        IEnumerable<TonKho> GetMultiByBookId(int idSach);

        bool CheckCreatePermission(int idSach, int creQuantity);

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

        public IEnumerable<TonKho> GetAll(string[] includes)
        {
            return tonKhoRepository.GetAll(includes);
        }

        public IEnumerable<TonKho> GetMultiByDateAndId(DateTime date, int idSach)
        {
            return tonKhoRepository.GetMulti(x => x.ThoiGian >= date && x.IdSach == idSach);
        }

        public TonKho GetSingleByIdAndDate(int idSach, DateTime date)
        {
            return tonKhoRepository.GetMulti(x => x.ThoiGian <= date && x.IdSach == idSach).OrderByDescending(x => x.ThoiGian).OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public bool CheckCreatePermission(int idSach, int creQuantity)
        {
            var deltas = GetMultiByBookId(idSach);
            int s = creQuantity;
            foreach(var tk in deltas)
            {
                s += (int)tk.TangGiam;
            }

            if (s >= 0)
                return true;

            return false;
        }

        public IEnumerable<TonKho> GetMultiByBookId(int idSach)
        {
            return tonKhoRepository.GetMulti(x => x.IdSach == idSach);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}