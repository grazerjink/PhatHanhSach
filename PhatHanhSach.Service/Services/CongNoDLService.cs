using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhatHanhSach.Service
{
    public interface ICongNoDLService
    {
        CongNoDL Add(CongNoDL congNoDL);

        void Update(CongNoDL congNoDL);

        CongNoDL Delete(CongNoDL congNoDL);

        IEnumerable<CongNoDL> GetAll();

        CongNoDL GetById(int id);

        double GetDeptInLastMonth(int id, DateTime startDate);

        void Save();
    }

    public class CongNoDLService : ICongNoDLService
    {
        private ICongNoDLRepository congNoDLRepository;
        private IUnitOfWork unitOfWork;

        public CongNoDLService(ICongNoDLRepository congNoDLRepository, IUnitOfWork unitOfWork)
        {
            this.congNoDLRepository = congNoDLRepository;
            this.unitOfWork = unitOfWork;
        }

        public CongNoDL Add(CongNoDL congNoDL)
        {
            return congNoDLRepository.Add(congNoDL);
        }

        public void Update(CongNoDL congNoDL)
        {
            congNoDLRepository.Update(congNoDL);
        }

        public CongNoDL Delete(CongNoDL congNoDL)
        {
            return congNoDLRepository.Delete(congNoDL);
        }

        public IEnumerable<CongNoDL> GetAll()
        {
            return congNoDLRepository.GetAll();
        }

        public CongNoDL GetById(int id)
        {
            return congNoDLRepository.GetSingleById(id);
        }

        public double GetDeptInLastMonth(int id, DateTime startDate)
        {
            var dept = congNoDLRepository.GetMulti(x => x.IdDaiLy == id && x.NgayCapNhat < startDate && x.TongTienThanhToan != 0).OrderByDescending(x => x.NgayCapNhat).Take(1).FirstOrDefault();
            return dept == null ? 0 : (double)dept.TongTienConNo;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}