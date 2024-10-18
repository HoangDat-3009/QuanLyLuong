﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class NhanVien
{
    [Key]
    public int MaNhanVien { get; set; }

    public string? HoTen { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? NoiSinh { get; set; }

    public DateOnly? NgayVaoCongTy { get; set; }

    public int? MaDanToc { get; set; }

    public int? MaChucVu { get; set; }

    public int? MaPhongBan { get; set; }

    public int? MaTrinhDo { get; set; }

    public int? MaChuyenMon { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public int? MaHeSo { get; set; }

    public string? Cccd { get; set; }

    public string? TaiKhoanNganHang { get; set; }

    public string? SoTaiKhoanNganHang { get; set; }

    public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();

    public virtual ChucVu? MaChucVuNavigation { get; set; }

    public virtual ChuyenMon? MaChuyenMonNavigation { get; set; }

    public virtual DanToc? MaDanTocNavigation { get; set; }

    public virtual HeSo? MaHeSoNavigation { get; set; }

    public virtual PhongBan? MaPhongBanNavigation { get; set; }

    public virtual TrinhDo? MaTrinhDoNavigation { get; set; }
}
