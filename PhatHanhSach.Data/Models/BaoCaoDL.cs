//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhatHanhSach.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaoCaoDL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoCaoDL()
        {
            this.CongNoDLs = new HashSet<CongNoDL>();
            this.CtBaoCaoDLs = new HashSet<CtBaoCaoDL>();
        }
    
        public string MaBaoCao { get; set; }
        public string MaDaiLy { get; set; }
        public Nullable<System.DateTime> ThoiGianBatDau { get; set; }
        public Nullable<System.DateTime> ThoiGianKetThuc { get; set; }
        public Nullable<System.DateTime> ThoiGianLap { get; set; }
        public Nullable<double> TongTien { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual DaiLy DaiLy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNoDL> CongNoDLs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CtBaoCaoDL> CtBaoCaoDLs { get; set; }
    }
}