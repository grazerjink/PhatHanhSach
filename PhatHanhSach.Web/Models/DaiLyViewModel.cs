using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhatHanhSach.Web.Models
{
    public class DaiLyViewModel
    {
        [Required(ErrorMessage="Mã đại lý không thể để trống.")]
        [MinLength(5,ErrorMessage="Mã đại lý bao gồm 2 ký tự và 3 chữ số.")]
        public string MaDaiLy { get; set; }

        [Required(ErrorMessage = "Tên đại lý không thể để trống.")]
        [MaxLength(250)]
        public string TenDaiLy { get; set; }

        [Required(ErrorMessage = "Số điện thoại không thể để trống.")]
        [MinLength(10, ErrorMessage = "Số điện thoại không hợp lệ.")]
        [MaxLength(11, ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Địa chỉ không thể để trống.")]
        [MaxLength(250)]
        public string DiaChi { get; set; }

        public bool TrangThai { get; set; }
    }
}