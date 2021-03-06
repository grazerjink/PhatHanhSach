﻿using PhatHanhSach.Common;
using PhatHanhSach.Data.Infrastructure;
using PhatHanhSach.Data.Repositories;
using PhatHanhSach.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhatHanhSach.Service
{
    public interface IThanhToanService
    {
        ThanhToan Add(ThanhToan thanhToan);

        void Update(ThanhToan thanhToan);

        ThanhToan Delete(ThanhToan thanhToan);

        IEnumerable<ThanhToan> GetAll(string[] includes = null);

        ThanhToan GetById(int id, string[] includes=null);

        List<ThongKeBaoCaoNXBViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate);

        void Save();

        DateTime? GetStartDateToCreateReport(int id);

        bool CheckReportIsCreated(int idNXB, DateTime currentCreateDate);
    }

    public class ThanhToanService : IThanhToanService
    {
        private IThanhToanRepository thanhToanRepository;
        private IUnitOfWork unitOfWork;

        public ThanhToanService(IThanhToanRepository thanhToanRepository, IUnitOfWork unitOfWork)
        {
            this.thanhToanRepository = thanhToanRepository;
            this.unitOfWork = unitOfWork;
        }

        public ThanhToan Add(ThanhToan thanhToan)
        {
            return thanhToanRepository.Add(thanhToan);
        }

        public void Update(ThanhToan thanhToan)
        {
            thanhToanRepository.Update(thanhToan);
        }

        public ThanhToan Delete(ThanhToan thanhToan)
        {
            return thanhToanRepository.Delete(thanhToan);
        }

        public IEnumerable<ThanhToan> GetAll(string[] includes = null)
        {
            return thanhToanRepository.GetAll(includes);
        }

        public ThanhToan GetById(int id, string[] includes = null)
        {
            return thanhToanRepository.GetSingleByCondition(x => x.Id == id, includes);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public List<ThongKeBaoCaoNXBViewModel> GetListAnalysisReport(int id, DateTime fromDate, DateTime toDate)
        {
            var listImportExport = thanhToanRepository.GetListImportedAndExported(id, fromDate, toDate);
            var oldMonthExistList = thanhToanRepository.GetListExistAtLastMonth(id, fromDate);            
            listImportExport.ForEach(x =>
            {
                int TongSoLuong = x.SoLuongNhap;
                if (oldMonthExistList.Count > 0)
                {
                    var existItem = oldMonthExistList.Find(y => y.Id == x.Id);
                    if (existItem != null)
                    {
                        x.SoLuongTonDotTruoc += existItem.SoLuongTon;
                        TongSoLuong += existItem.SoLuongTon;
                    }
                }
                x.TongTienNhap = TongSoLuong * x.DonGiaNhap;

                if(x.TongTienXuat != null)
                {
                    x.TongTienNo = x.TongTienNhap - (double)x.TongTienXuat;
                }
                else
                {
                    x.TongTienNo = x.TongTienNhap;
                }
                
                
            });
            return listImportExport;
        }

        public bool CheckReportIsCreated(int idNXB, DateTime currentCreateDate)
        {
            var dsBaoCaoDaTao = thanhToanRepository.GetMulti(x => x.NgayKetThuc >= currentCreateDate && x.IdNXB == idNXB && (x.IdTinhTrang == 1 || x.IdTinhTrang == 2)).ToList();
            if (dsBaoCaoDaTao.Count != 0) return true; // Report has created before.
            return false;
        }

        public DateTime? GetStartDateToCreateReport(int id)
        {
            var baoCao = thanhToanRepository.GetMulti(x => x.IdNXB == id).OrderByDescending(x => x.NgayKetThuc).FirstOrDefault();
            if (baoCao != null)
                return baoCao.NgayKetThuc.Value.AddDays(1);
            else
                return null;
        }
    }
}