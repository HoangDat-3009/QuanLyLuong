using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class Luong
{
    public int MaLuong { get; set; }

    public int? MaNhanVien { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public double? HeSo { get; set; }

    public decimal? Luong1 { get; set; }

    public decimal? PhuCapChucVu { get; set; }

    public decimal? PhuCapTrinhDo { get; set; }

    public decimal? Bhyt { get; set; }

    public decimal? Bhtn { get; set; }

    public decimal? Bhxh { get; set; }

    public decimal? KhenThuongKyLuat { get; set; }

    public decimal? ThucLinh { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
