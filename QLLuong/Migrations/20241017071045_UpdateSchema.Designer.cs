
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using QLLuong.Data;

#nullable disable

namespace QLLuong.Migrations
{
    [DbContext(typeof(QLLuongContext))]
    [Migration("20241017071045_UpdateSchema")]
    partial class UpdateSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("QLLuong.Models.PhongBan", b =>
                {
                    b.Property<int>("MaPhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhongBan"));

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhongBan");

                    b.ToTable("PhongBan");
                });
#pragma warning restore 612, 618
        }
    }
}
