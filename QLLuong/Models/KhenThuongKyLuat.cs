using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class KhenThuongKyLuat
{
    public int MaKtkl { get; set; }

    public int? MaNhanVien { get; set; }

    public string? LoaiKtkl { get; set; }

    public int? Thang { get; set; }

    public int? Nam { get; set; }

    public int? MaLyDo { get; set; }

    public decimal? SoTien { get; set; }

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    public virtual LyDoKtkl? MaLyDoNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
