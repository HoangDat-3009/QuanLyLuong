using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class ChamCong
{
    public int ChamCongId { get; set; }

    public int MaNhanVien { get; set; }

    public DateTime? NgayGioVao { get; set; }

    public DateTime? NgayGioRa { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
