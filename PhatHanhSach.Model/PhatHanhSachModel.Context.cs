﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhatHanhSach.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhatHanhSachEntities : DbContext
    {
        public PhatHanhSachEntities()
            : base("name=PhatHanhSachEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaoCaoDL> BaoCaoDLs { get; set; }
        public virtual DbSet<CongNoDL> CongNoDLs { get; set; }
        public virtual DbSet<CongNoNXB> CongNoNXBs { get; set; }
        public virtual DbSet<CtBaoCaoDL> CtBaoCaoDLs { get; set; }
        public virtual DbSet<CtDoanhThu> CtDoanhThus { get; set; }
        public virtual DbSet<CtPhieuNhap> CtPhieuNhaps { get; set; }
        public virtual DbSet<CtPhieuXuat> CtPhieuXuats { get; set; }
        public virtual DbSet<CtThanhToan> CtThanhToans { get; set; }
        public virtual DbSet<DaiLy> DaiLies { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<TinhTrang> TinhTrangs { get; set; }
        public virtual DbSet<TonKho> TonKhoes { get; set; }
    }
}
