using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System.Collections.Generic;

namespace PhatHanhSach.Service
{
    public interface IDaiLyService
    {
        DaiLy Add(DaiLy daiLy);

        void Update(DaiLy daiLy);

        DaiLy Delete(DaiLy daiLy);

        IEnumerable<DaiLy> GetAll();

        IEnumerable<DaiLy> GetAllActive();

        DaiLy GetById(int code);

        DaiLy GetSingleByName(string name, bool status = true);

        void Save();
    }

    public class DaiLyService : IDaiLyService
    {
        private IDaiLyRepository daiLyRepository;
        private IUnitOfWork unitOfWork;

        public DaiLyService(IDaiLyRepository daiLyRepository, IUnitOfWork unitOfWork)
        {
            this.daiLyRepository = daiLyRepository;
            this.unitOfWork = unitOfWork;
        }

        public DaiLy Add(DaiLy daiLy)
        {
            return daiLyRepository.Add(daiLy);
        }

        public void Update(DaiLy daiLy)
        {
            daiLyRepository.Update(daiLy);
        }

        public DaiLy Delete(DaiLy daiLy)
        {
            return daiLyRepository.Delete(daiLy);
        }

        public IEnumerable<DaiLy> GetAll()
        {
            return daiLyRepository.GetAll();
        }

        public IEnumerable<DaiLy> GetAllActive()
        {
            return daiLyRepository.GetMulti(x => x.TrangThai == true);
        }

        public DaiLy GetById(int id)
        {
            return daiLyRepository.GetSingleById(id);
        }

        public DaiLy GetSingleByName(string name, bool status = true)
        {
            return daiLyRepository.GetSingleByCondition(x => x.TenDaiLy.Equals(name) && x.TrangThai == status);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}