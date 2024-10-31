using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class UserLogin
{
    public int MaNhanVien { get; set; }

    public string? Username { get; set; }

    public string? Userpassword { get; set; }

    public int? MaQuyen { get; set; }

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;

    public virtual Quyen? MaQuyenNavigation { get; set; }
}
