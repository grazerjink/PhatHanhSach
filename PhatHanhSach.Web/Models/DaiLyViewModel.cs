﻿using System.ComponentModel.DataAnnotations;

namespace PhatHanhSach.Web.Models
{
    public class DaiLyViewModel : BaseViewModel
    {
        [Required]
        public int Id { get; set; }

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

        public CongNoDLViewModel CongNoDL { get; set; }
    }
}