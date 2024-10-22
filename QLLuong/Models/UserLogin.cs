﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
    public partial class UserLogin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản")]
        public string Username { get; set; } 
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Userpassword { get; set; } = null!;
    }
}   

