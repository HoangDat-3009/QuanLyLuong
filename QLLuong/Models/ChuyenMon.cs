using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class ChuyenMon
{
    [Key]
    public int MaChuyenMon { get; set; }

    public string? TenChuyenMon { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
