
﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QLLuong.Models;

namespace QLLuong.Data;

public partial class QLLuongContext : DbContext
{
    public QLLuongContext()
    {
    }

    public QLLuongContext(DbContextOptions<QLLuongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChamCong> ChamCongs { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<ChuyenMon> ChuyenMons { get; set; }

    public virtual DbSet<DanToc> DanTocs { get; set; }

    public virtual DbSet<HeSo> HeSos { get; set; }

    public virtual DbSet<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<LuongCoBanPhanTramBh> LuongCoBanPhanTramBhs { get; set; }

    public virtual DbSet<LuongCu> LuongCus { get; set; }

    public virtual DbSet<LyDoKtkl> LyDoKtkls { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChamCong>(entity =>
        {
            entity.HasKey(e => e.ChamCongId).HasName("PK__ChamCong__9D16AF61FF33F476");

            entity.ToTable("ChamCong");

            entity.Property(e => e.ChamCongId).HasColumnName("ChamCongID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayGioRa).HasColumnType("datetime");
            entity.Property(e => e.NgayGioVao).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__ChamCong__MaNhan__619B8048");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D46395331BE380FA");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenChucVu).HasMaxLength(100);
        });

        modelBuilder.Entity<ChuyenMon>(entity =>
        {
            entity.HasKey(e => e.MaChuyenMon).HasName("PK__ChuyenMo__9A6A232125687042");

            entity.ToTable("ChuyenMon");

            entity.Property(e => e.MaChuyenMon).ValueGeneratedNever();
            entity.Property(e => e.TenChuyenMon).HasMaxLength(100);
        });

        modelBuilder.Entity<DanToc>(entity =>
        {
            entity.HasKey(e => e.MaDanToc).HasName("PK__DanToc__A5FA09701FB4C3D8");

            entity.ToTable("DanToc");

            entity.Property(e => e.MaDanToc).ValueGeneratedNever();
            entity.Property(e => e.TenDanToc).HasMaxLength(50);
        });

        modelBuilder.Entity<HeSo>(entity =>
        {
            entity.HasKey(e => e.MaHeSo).HasName("PK__HeSo__0C16CD3D0B98CCCE");

            entity.ToTable("HeSo");

            entity.Property(e => e.MaHeSo).ValueGeneratedNever();
        });

        modelBuilder.Entity<KhenThuongKyLuat>(entity =>
        {
            entity.HasKey(e => e.MaKtkl).HasName("PK__KhenThuo__4019B9562F09916A");

            entity.ToTable("KhenThuongKyLuat");

            entity.Property(e => e.MaKtkl)
                .ValueGeneratedNever()
                .HasColumnName("MaKTKL");
            entity.Property(e => e.LoaiKtkl)
                .HasMaxLength(50)
                .HasColumnName("LoaiKTKL");
            entity.Property(e => e.SoTien).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.MaLyDoNavigation).WithMany(p => p.KhenThuongKyLuats)
                .HasForeignKey(d => d.MaLyDo)
                .HasConstraintName("FK__KhenThuon__MaLyD__656C112C");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.KhenThuongKyLuats)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__KhenThuon__MaNha__6477ECF3");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__Luong__6609A48D34E6B263");

            entity.ToTable("Luong");

            entity.Property(e => e.MaKtkl).HasColumnName("MaKTKL");
            entity.Property(e => e.MaLuongCoBanPhanTramBh).HasColumnName("MaLuongCoBan_PhanTramBH");

            entity.HasOne(d => d.MaKtklNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaKtkl)
                .HasConstraintName("FK__Luong__MaKTKL__68487DD7");

            entity.HasOne(d => d.MaLuongCoBanPhanTramBhNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaLuongCoBanPhanTramBh)
                .HasConstraintName("FK__Luong__MaLuongCo__6A30C649");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__Luong__MaNhanVie__693CA210");
        });

        modelBuilder.Entity<LuongCoBanPhanTramBh>(entity =>
        {
            entity.HasKey(e => e.MaLuongCoBanPhanTramBh).HasName("PK__LuongCoB__EDBBAA727F8BBC55");

            entity.ToTable("LuongCoBan_PhanTramBH");

            entity.Property(e => e.MaLuongCoBanPhanTramBh)
                .ValueGeneratedNever()
                .HasColumnName("MaLuongCoBan_PhanTramBH");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PhanTramBhtn).HasColumnName("PhanTramBHTN");
            entity.Property(e => e.PhanTramBhxh).HasColumnName("PhanTramBHXH");
            entity.Property(e => e.PhanTramBhyt).HasColumnName("PhanTramBHYT");
        });

        modelBuilder.Entity<LuongCu>(entity =>
        {
            entity.HasKey(e => e.MaLuongCu).HasName("PK__LuongCu__A3152324ECD8EBFA");

            entity.ToTable("LuongCu");

            entity.Property(e => e.Bhtn)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("BHTN");
            entity.Property(e => e.Bhxh)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("BHXH");
            entity.Property(e => e.Bhyt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("BHYT");
            entity.Property(e => e.KhenThuongKyLuat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PhuCapChucVu).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PhuCapTrinhDo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ThucLinh).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.LuongCus)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__LuongCu__MaNhanV__72C60C4A");
        });

        modelBuilder.Entity<LyDoKtkl>(entity =>
        {
            entity.HasKey(e => e.MaLyDo).HasName("PK__LyDoKTKL__28E8B61E52A5F6D5");

            entity.ToTable("LyDoKTKL");

            entity.Property(e => e.MaLyDo).ValueGeneratedNever();
            entity.Property(e => e.TenLyDo).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47EFA648BE");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NoiSinh).HasMaxLength(100);
            entity.Property(e => e.SoTaiKhoanNganHang).HasMaxLength(50);
            entity.Property(e => e.TaiKhoanNganHang).HasMaxLength(100);

            entity.HasOne(d => d.MaChucVuNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChucVu)
                .HasConstraintName("FK__NhanVien__MaChuc__5AEE82B9");

            entity.HasOne(d => d.MaChuyenMonNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChuyenMon)
                .HasConstraintName("FK__NhanVien__MaChuy__5DCAEF64");

            entity.HasOne(d => d.MaDanTocNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaDanToc)
                .HasConstraintName("FK__NhanVien__MaDanT__59FA5E80");

            entity.HasOne(d => d.MaHeSoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaHeSo)
                .HasConstraintName("FK__NhanVien__MaHeSo__5EBF139D");

            entity.HasOne(d => d.MaPhongBanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhongBan)
                .HasConstraintName("FK__NhanVien__MaPhon__5BE2A6F2");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTrinhDo)
                .HasConstraintName("FK__NhanVien__MaTrin__5CD6CB2B");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan).HasName("PK__PhongBan__D0910CC85F4E30D4");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhongBan).ValueGeneratedNever();
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.TenPhongBan).HasMaxLength(100);
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__Quyen__1D4B7ED488D5E85F");

            entity.ToTable("Quyen");

            entity.Property(e => e.MaQuyen).ValueGeneratedNever();
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo).HasName("PK__TrinhDo__B64C90D3DFA8268D");

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenTrinhDo).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__UserLogi__77B2CA47EA39A939");

            entity.ToTable("UserLogin");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(255)
                .HasColumnName("userpassword");

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.UserLogin)
                .HasForeignKey<UserLogin>(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLogin__MaNha__6EF57B66");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.MaQuyen)
                .HasConstraintName("FK__UserLogin__MaQuy__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
