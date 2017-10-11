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
    public interface IDaiLyService
    {
        DaiLy Add(DaiLy daiLy);

        void Update(DaiLy daiLy);

        DaiLy Delete(DaiLy daiLy);

        IEnumerable<DaiLy> GetAll();

        DaiLy GetByCode(string code);

        void Save();
    }

    public class DaiLyService : IDaiLyService
    {
        private IDaiLyRepository daiLyRepository;
        private IUnitOfWork unitOfWork;

        public DaiLyService(IDaiLyRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.daiLyRepository = postCategoryRepository;
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
    
        public DaiLy GetByCode(string code)
        {
            return daiLyRepository.GetSingleByStringCodeId(code);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
