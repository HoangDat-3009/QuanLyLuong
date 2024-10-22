using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class LyDoKtkl
{
    public int MaLyDo { get; set; }

    public string? TenLyDo { get; set; }

    public virtual ICollection<KhenThuongKyLuat> KhenThuongKyLuats { get; set; } = new List<KhenThuongKyLuat>();
}
