using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class NhanVien
{
    [Key]
    public int MaNhanVien { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? HoTen { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? GioiTinh { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public DateOnly? NgaySinh { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? NoiSinh { get; set; }

    public DateOnly? NgayVaoCongTy { get; set; }

    public int? MaDanToc { get; set; }

    public int? MaChucVu { get; set; }

    public int? MaPhongBan { get; set; }

    public int? MaTrinhDo { get; set; }

    public int? MaChuyenMon { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? DiaChi { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? DienThoai { get; set; }
    public bool IsDeleted { get; set; }

    public int? MaHeSo { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? Cccd { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? TaiKhoanNganHang { get; set; }
    [Required(ErrorMessage = "Không được bỏ trống mục này")]
    public string? SoTaiKhoanNganHang { get; set; }

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();

    public virtual ICollection<KhenThuongKyLuat> KhenThuongKyLuats { get; set; } = new List<KhenThuongKyLuat>();

    public virtual ICollection<LuongCu> LuongCus { get; set; } = new List<LuongCu>();

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    public virtual ChucVu? MaChucVuNavigation { get; set; }

    public virtual ChuyenMon? MaChuyenMonNavigation { get; set; }

    public virtual DanToc? MaDanTocNavigation { get; set; }

    public virtual HeSo? MaHeSoNavigation { get; set; }

    public virtual PhongBan? MaPhongBanNavigation { get; set; }

    public virtual TrinhDo? MaTrinhDoNavigation { get; set; }

    public virtual UserLogin? UserLogin { get; set; }
}