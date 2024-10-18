using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class LuongCoBan
{
    [Key]
    public int MaLuongCoBan { get; set; }

    public decimal? LuongCoBan1 { get; set; }
}
