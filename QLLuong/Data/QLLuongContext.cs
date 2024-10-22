
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

    public virtual DbSet<LyDoKtkl> LyDoKtkls { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhanVienDaNghiViec> NhanVienDaNghiViecs { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NGUYENBIEN\\SQLEXPRESS;Initial Catalog=QLLuong;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<NhanVien>().HasQueryFilter(nv => !nv.IsDeleted);

		modelBuilder.Entity<ChamCong>(entity =>
        {
            entity.HasKey(e => e.ChamCongId).HasName("PK__ChamCong__9D16AF613091FEAC");

            entity.ToTable("ChamCong");

            entity.Property(e => e.ChamCongId).HasColumnName("ChamCongID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayGioRa).HasColumnType("datetime");
            entity.Property(e => e.NgayGioVao).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.ChamCongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__ChamCong__MaNhan__60A75C0F");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D4639533225348B7");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenChucVu).HasMaxLength(100);
        });

        modelBuilder.Entity<ChuyenMon>(entity =>
        {
            entity.HasKey(e => e.MaChuyenMon).HasName("PK__ChuyenMo__9A6A23219205454B");

            entity.ToTable("ChuyenMon");

            entity.Property(e => e.MaChuyenMon).ValueGeneratedNever();
            entity.Property(e => e.TenChuyenMon).HasMaxLength(100);
        });

        modelBuilder.Entity<DanToc>(entity =>
        {
            entity.HasKey(e => e.MaDanToc).HasName("PK__DanToc__A5FA0970D34914F9");

            entity.ToTable("DanToc");

            entity.Property(e => e.MaDanToc).ValueGeneratedNever();
            entity.Property(e => e.TenDanToc).HasMaxLength(50);
        });

        modelBuilder.Entity<HeSo>(entity =>
        {
            entity.HasKey(e => e.MaHeSo).HasName("PK__HeSo__0C16CD3D6D80D345");

            entity.ToTable("HeSo");

            entity.Property(e => e.MaHeSo).ValueGeneratedNever();
        });

        modelBuilder.Entity<KhenThuongKyLuat>(entity =>
        {
            entity.HasKey(e => e.MaKtkl).HasName("PK__KhenThuo__4019B956708EE729");

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
                .HasConstraintName("FK__KhenThuon__MaLyD__04E4BC85");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.KhenThuongKyLuats)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__KhenThuon__MaNha__03F0984C");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__Luong__6609A48D5AA62083");

            entity.ToTable("Luong");

            entity.Property(e => e.MaKtkl).HasColumnName("MaKTKL");
            entity.Property(e => e.MaLuongCoBanPhanTramBh).HasColumnName("MaLuongCoBan_PhanTramBH");

            entity.HasOne(d => d.MaKtklNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaKtkl)
                .HasConstraintName("FK__Luong__MaKTKL__05D8E0BE");

            entity.HasOne(d => d.MaLuongCoBanPhanTramBhNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaLuongCoBanPhanTramBh)
                .HasConstraintName("FK__Luong__MaLuongCo__6477ECF3");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__Luong__MaNhanVie__6383C8BA");
        });

        modelBuilder.Entity<LuongCoBanPhanTramBh>(entity =>
        {
            entity.HasKey(e => e.MaLuongCoBanPhanTramBh).HasName("PK__LuongCoB__EDBBAA72C5AFCE92");

            entity.ToTable("LuongCoBan_PhanTramBH");

            entity.Property(e => e.MaLuongCoBanPhanTramBh)
                .ValueGeneratedNever()
                .HasColumnName("MaLuongCoBan_PhanTramBH");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PhanTramBhtn).HasColumnName("PhanTramBHTN");
            entity.Property(e => e.PhanTramBhxh).HasColumnName("PhanTramBHXH");
            entity.Property(e => e.PhanTramBhyt).HasColumnName("PhanTramBHYT");
        });

        modelBuilder.Entity<LyDoKtkl>(entity =>
        {
            entity.HasKey(e => e.MaLyDo).HasName("PK__LyDoKTKL__28E8B61EDE463E26");

            entity.ToTable("LyDoKTKL");

            entity.Property(e => e.MaLyDo).ValueGeneratedNever();
            entity.Property(e => e.TenLyDo).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47443858AA");

            entity.ToTable("NhanVien", tb => tb.HasTrigger("update_luong_from_nv"));

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
                .HasConstraintName("FK__NhanVien__MaChuc__59FA5E80");

            entity.HasOne(d => d.MaChuyenMonNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChuyenMon)
                .HasConstraintName("FK__NhanVien__MaChuy__5CD6CB2B");

            entity.HasOne(d => d.MaDanTocNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaDanToc)
                .HasConstraintName("FK__NhanVien__MaDanT__59063A47");

            entity.HasOne(d => d.MaHeSoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaHeSo)
                .HasConstraintName("FK__NhanVien__MaHeSo__5DCAEF64");

            entity.HasOne(d => d.MaPhongBanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhongBan)
                .HasConstraintName("FK__NhanVien__MaPhon__5AEE82B9");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTrinhDo)
                .HasConstraintName("FK__NhanVien__MaTrin__5BE2A6F2");
        });

        modelBuilder.Entity<NhanVienDaNghiViec>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47D92B47D3");

            entity.ToTable("NhanVienDaNghiViec");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.Cccd).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NgayNghiViec)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoiSinh).HasMaxLength(255);
            entity.Property(e => e.SoTaiKhoanNganHang).HasMaxLength(50);
            entity.Property(e => e.TaiKhoanNganHang).HasMaxLength(255);
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan).HasName("PK__PhongBan__D0910CC8C4AAD809");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhongBan).ValueGeneratedNever();
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.TenPhongBan).HasMaxLength(100);
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo).HasName("PK__TrinhDo__B64C90D36890B05F");

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenTrinhDo).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3213E83FE7597B88");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(255)
                .HasColumnName("userpassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
