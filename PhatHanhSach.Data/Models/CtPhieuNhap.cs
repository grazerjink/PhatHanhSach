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
    
    public partial class CtPhieuNhap
    {
        public int Id { get; set; }
        public string MaPhieuNhap { get; set; }
        public string MaSach { get; set; }
        public Nullable<int> SoLuongNhap { get; set; }
        public Nullable<double> GiaNhap { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    
        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
