using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class TrinhDo
{
    public int MaTrinhDo { get; set; }

    public string? TenTrinhDo { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
