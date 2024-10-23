using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class LuongCoBanPhanTramBh
{
    public int MaLuongCoBanPhanTramBh { get; set; }

    public decimal? LuongCoBan { get; set; }

    [Required(ErrorMessage ="K duoc bo trong")]
    [Range(0,100,ErrorMessage ="0-100")]
    
    public double? PhanTramBhyt { get; set; }
    [Range(0, 100, ErrorMessage = "0-100")]
    [Required(ErrorMessage = "K duoc bo trong")]
    public double? PhanTramBhtn { get; set; }
    [Range(0, 100, ErrorMessage = "0-100")]
    [Required(ErrorMessage = "K duoc bo trong")]
    public double? PhanTramBhxh { get; set; }

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();
}
