﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLLuong.Data;

#nullable disable

namespace QLLuong.Migrations
{
    [DbContext(typeof(QLLuongContext))]
    partial class QLLuongContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLLuong.Models.KTKL", b =>
                {
                    b.Property<int>("MaKTKL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKTKL"));

                    b.Property<string>("LoaiKTKL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaLyDo")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<string>("SoTien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Thang")
                        .HasColumnType("int");

                    b.HasKey("MaKTKL");

                    b.ToTable("KTKL");
                });

            modelBuilder.Entity("QLLuong.Models.Luong", b =>
                {
                    b.Property<int>("MaLuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLuong"));

                    b.Property<float?>("BHTN")
                        .HasColumnType("real");

                    b.Property<float?>("BHXH")
                        .HasColumnType("real");

                    b.Property<float?>("BHYT")
                        .HasColumnType("real");

                    b.Property<float?>("HeSo")
                        .HasColumnType("real");

                    b.Property<float?>("KhenThuongKyLuat")
                        .HasColumnType("real");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<float?>("PhuCapChucVu")
                        .HasColumnType("real");

                    b.Property<float?>("PhuCapTrinhDo")
                        .HasColumnType("real");

                    b.Property<int?>("Thang")
                        .HasColumnType("int");

                    b.Property<float?>("ThucLinh")
                        .HasColumnType("real");

                    b.Property<float?>("luong")
                        .HasColumnType("real");

                    b.HasKey("MaLuong");

                    b.ToTable("Luong");
                });

            modelBuilder.Entity("QLLuong.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaChucVu")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MaChuyenMon")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MaDanToc")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MaHeSo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MaPhongBan")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MaTrinhDo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiSinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien");

                    b.ToTable("NhanVien");
                });
#pragma warning restore 612, 618
        }
    }
}
