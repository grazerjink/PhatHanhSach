//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class BaoCaoDL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoCaoDL()
        {
            this.CtBaoCaoDLs = new HashSet<CtBaoCaoDL>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdDaiLy { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<System.DateTime> ThoiGianLapPhieu { get; set; }
        public Nullable<double> TongTienThanhToan { get; set; }
        public Nullable<double> TongTienConNo { get; set; }
        public Nullable<int> IdTinhTrang { get; set; }
        public Nullable<System.DateTime> NgayXacNhan { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual DaiLy DaiLy { get; set; }
        public virtual TinhTrang TinhTrang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CtBaoCaoDL> CtBaoCaoDLs { get; set; }
    }
}
