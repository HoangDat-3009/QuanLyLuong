using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class ChuyenMon
{
    public int MaChuyenMon { get; set; }

    public string? TenChuyenMon { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
