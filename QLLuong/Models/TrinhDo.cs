using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class TrinhDo
{
    [Key]
    public int MaTrinhDo { get; set; }

    public string? TenTrinhDo { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
