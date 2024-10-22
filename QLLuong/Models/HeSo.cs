using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class HeSo
{
    public int MaHeSo { get; set; }

    public double? HeSoLuong { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
