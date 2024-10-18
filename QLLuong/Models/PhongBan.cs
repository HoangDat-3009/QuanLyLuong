using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class PhongBan
{
    [Key]
    public int MaPhongBan { get; set; }

    public string? TenPhongBan { get; set; }

    public string? DienThoai { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
