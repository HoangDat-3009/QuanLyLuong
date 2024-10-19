
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

    public virtual DbSet<LuongCoBan> LuongCoBans { get; set; }

    public virtual DbSet<LyDoKtkl> LyDoKtkls { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=HUNG\\SQLEXPRESS;Initial Catalog=QLLuong;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChamCong>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChamCong");
            entity.HasKey(e => e.MaNhanVien);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.NgayGioRa).HasColumnType("datetime");
            entity.Property(e => e.NgayGioVao).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany()
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__ChamCong__MaNhan__6754599E");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D463953359346141");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenChucVu).HasMaxLength(100);
        });

        modelBuilder.Entity<ChuyenMon>(entity =>
        {
            entity.HasKey(e => e.MaChuyenMon).HasName("PK__ChuyenMo__9A6A23216EA0151C");

            entity.ToTable("ChuyenMon");

            entity.Property(e => e.MaChuyenMon).ValueGeneratedNever();
            entity.Property(e => e.TenChuyenMon).HasMaxLength(100);
        });

        modelBuilder.Entity<DanToc>(entity =>
        {
            entity.HasKey(e => e.MaDanToc).HasName("PK__DanToc__A5FA0970C9E0330F");

            entity.ToTable("DanToc");

            entity.Property(e => e.MaDanToc).ValueGeneratedNever();
            entity.Property(e => e.TenDanToc).HasMaxLength(50);
        });

        modelBuilder.Entity<HeSo>(entity =>
        {
            entity.HasKey(e => e.MaHeSo).HasName("PK__HeSo__0C16CD3DDACDE2E9");

            entity.ToTable("HeSo");

            entity.Property(e => e.MaHeSo).ValueGeneratedNever();
        });

        modelBuilder.Entity<KhenThuongKyLuat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KhenThuongKyLuat");
            entity.HasKey(e => e.MaKtkl);
            entity.Property(e => e.LoaiKtkl)
                .HasMaxLength(50)
                .HasColumnName("LoaiKTKL");
            entity.Property(e => e.MaKtkl).HasColumnName("MaKTKL");
            entity.Property(e => e.SoTien).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.MaLyDoNavigation).WithMany()
                .HasForeignKey(d => d.MaLyDo)
                .HasConstraintName("FK__KhenThuon__MaLyD__6D0D32F4");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany()
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__KhenThuon__MaNha__6C190EBB");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__Luong__6609A48D03F257E2");

            entity.ToTable("Luong");

            entity.Property(e => e.MaLuong).ValueGeneratedNever();
            entity.Property(e => e.Bhtn)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("BHTN");
            entity.Property(e => e.Bhxh)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("BHXH");
            entity.Property(e => e.Bhyt)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("BHYT");
            entity.Property(e => e.KhenThuongKyLuat).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Luong1)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("Luong");
            entity.Property(e => e.PhuCapChucVu).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PhuCapTrinhDo).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ThucLinh).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.Luongs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__Luong__MaNhanVie__6A30C649");
        });

        modelBuilder.Entity<LuongCoBan>(entity =>
        {
            entity.HasKey(e => e.MaLuongCoBan).HasName("PK__LuongCoB__542BDA5FA898E9B5");

            entity.ToTable("LuongCoBan");

            entity.Property(e => e.MaLuongCoBan).ValueGeneratedNever();
            entity.Property(e => e.LuongCoBan1)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("LuongCoBan");
        });

        modelBuilder.Entity<LyDoKtkl>(entity =>
        {
            entity.HasKey(e => e.MaLyDo).HasName("PK__LyDoKTKL__28E8B61E81D03FA8");

            entity.ToTable("LyDoKTKL");

            entity.Property(e => e.MaLyDo).ValueGeneratedNever();
            entity.Property(e => e.TenLyDo).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA4773660A31");

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
                .HasConstraintName("FK__NhanVien__MaChuc__619B8048");

            entity.HasOne(d => d.MaChuyenMonNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChuyenMon)
                .HasConstraintName("FK__NhanVien__MaChuy__6477ECF3");

            entity.HasOne(d => d.MaDanTocNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaDanToc)
                .HasConstraintName("FK__NhanVien__MaDanT__60A75C0F");

            entity.HasOne(d => d.MaHeSoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaHeSo)
                .HasConstraintName("FK__NhanVien__MaHeSo__656C112C");

            entity.HasOne(d => d.MaPhongBanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhongBan)
                .HasConstraintName("FK__NhanVien__MaPhon__628FA481");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTrinhDo)
                .HasConstraintName("FK__NhanVien__MaTrin__6383C8BA");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan).HasName("PK__PhongBan__D0910CC8CDCC7106");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhongBan).ValueGeneratedNever();
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.TenPhongBan).HasMaxLength(100);
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo).HasName("PK__TrinhDo__B64C90D359CB8978");

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo).ValueGeneratedNever();
            entity.Property(e => e.PhuCap).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TenTrinhDo).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3213E83FF4866A6C");

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
