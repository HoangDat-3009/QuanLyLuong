using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
    public partial class UserLogin
    {
        [Key]
        public int MaNhanVien { get; set; }

        public string? Username { get; set; }

        public string? Userpassword { get; set; }

        public int? MaQuyen { get; set; }

        public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

        public virtual Quyen? MaQuyenNavigation { get; set; }
    }
}   

