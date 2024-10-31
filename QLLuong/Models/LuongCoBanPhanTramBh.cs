using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class LuongCoBanPhanTramBh
{
    public int MaLuongCoBanPhanTramBh { get; set; }

    public decimal? LuongCoBan { get; set; }

    public double? PhanTramBhyt { get; set; }

    public double? PhanTramBhtn { get; set; }

    public double? PhanTramBhxh { get; set; }

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();
}
