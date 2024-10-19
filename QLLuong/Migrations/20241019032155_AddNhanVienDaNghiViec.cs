using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLLuong.Migrations
{
    /// <inheritdoc />
    public partial class AddNhanVienDaNghiViec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanVienDaNghiViecs",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayVaoCongTy = table.Column<DateOnly>(type: "date", nullable: true),
                    MaDanToc = table.Column<int>(type: "int", nullable: true),
                    MaChucVu = table.Column<int>(type: "int", nullable: true),
                    MaPhongBan = table.Column<int>(type: "int", nullable: true),
                    MaTrinhDo = table.Column<int>(type: "int", nullable: true),
                    MaChuyenMon = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHeSo = table.Column<int>(type: "int", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayNghiViec = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienDaNghiViecs", x => x.MaNhanVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVienDaNghiViecs");
        }
    }
}
