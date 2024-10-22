using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class DanToc
{
    public int MaDanToc { get; set; }

    public string? TenDanToc { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
