using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLLuong.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KTKL",
                columns: table => new
                {
                    MaKTKL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    LoaiKTKL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    MaLyDo = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KTKL", x => x.MaKTKL);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    HeSo = table.Column<float>(type: "real", nullable: true),
                    luong = table.Column<float>(type: "real", nullable: true),
                    PhuCapChucVu = table.Column<float>(type: "real", nullable: true),
                    PhuCapTrinhDo = table.Column<float>(type: "real", nullable: true),
                    BHYT = table.Column<float>(type: "real", nullable: true),
                    BHTN = table.Column<float>(type: "real", nullable: true),
                    BHXH = table.Column<float>(type: "real", nullable: true),
                    KhenThuongKyLuat = table.Column<float>(type: "real", nullable: true),
                    ThucLinh = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.MaLuong);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDanToc = table.Column<int>(type: "int", nullable: false),
                    MaChucVu = table.Column<int>(type: "int", nullable: false),
                    MaPhongBan = table.Column<int>(type: "int", nullable: false),
                    MaTrinhDo = table.Column<int>(type: "int", nullable: false),
                    MaChuyenMon = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaHeSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KTKL");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
