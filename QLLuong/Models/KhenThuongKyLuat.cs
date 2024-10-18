using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class KhenThuongKyLuat
{
    [Key]
    public int MaKtkl { get; set; }

    public int? MaNhanVien { get; set; }

    public string? LoaiKtkl { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public int? MaLyDo { get; set; }

    public decimal? SoTien { get; set; }

    public virtual LyDoKtkl? MaLyDoNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
