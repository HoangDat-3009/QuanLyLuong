using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLLuong.Models;

public partial class Luong
{
    [Key]
    public int MaLuong { get; set; }

    public int? MaLuongCoBan_PhanTramBH { get; set; }   

    public int? MaNhanVien { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public float? HeSo { get; set; }

    public decimal? Luong1 { get; set; }

    public decimal? PhuCapChucVu { get; set; }

    public decimal? PhuCapTrinhDo { get; set; }

    public decimal? BHYT { get; set; }

    public decimal? BHTN { get; set; }

    public decimal? BHXH { get; set; }

    public decimal? KhenThuongKyLuat { get; set; }

    public decimal? ThucLinh { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
    public virtual LuongCoBan_PhanTramBH? LuongCoBan_PhanTramBH { get; set; }
}
