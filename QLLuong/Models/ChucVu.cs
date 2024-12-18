﻿using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class ChucVu
{
    public int MaChucVu { get; set; }

    public string? TenChucVu { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
