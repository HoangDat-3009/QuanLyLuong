using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class Luong
{
    public int MaLuong { get; set; }

    public int? MaLuongCoBanPhanTramBh { get; set; }

    public int? MaNhanVien { get; set; }

    public int? MaKtkl { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public virtual KhenThuongKyLuat? MaKtklNavigation { get; set; }

    public virtual LuongCoBanPhanTramBh? MaLuongCoBanPhanTramBhNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
