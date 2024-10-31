using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class LuongCu
{
    public LuongCu() { }
    public int MaLuongCu { get; set; }

    public int? MaNhanVien { get; set; }

    public int Thang { get; set; }

    public int Nam { get; set; }

    public decimal? LuongCoBan { get; set; }

    public double? HeSo { get; set; }

    public decimal? PhuCapChucVu { get; set; }

    public decimal? PhuCapTrinhDo { get; set; }

    public decimal? Bhyt { get; set; }

    public decimal? Bhtn { get; set; }

    public decimal? Bhxh { get; set; }

    public decimal? KhenThuongKyLuat { get; set; }

    public int? SoCong { get; set; }

    public decimal? ThucLinh { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
