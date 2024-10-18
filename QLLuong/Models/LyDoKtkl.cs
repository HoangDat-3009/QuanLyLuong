using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class LyDoKtkl
{
    [Key]
    public int MaLyDo { get; set; }

    public string? TenLyDo { get; set; }
}
