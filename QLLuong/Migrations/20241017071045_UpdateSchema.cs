using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLLuong.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KTKL");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    MaPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.MaPhongBan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.CreateTable(
                name: "KTKL",
                columns: table => new
                {
                    MaKTKL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiKTKL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLyDo = table.Column<int>(type: "int", nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true)
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
                    BHTN = table.Column<float>(type: "real", nullable: true),
                    BHXH = table.Column<float>(type: "real", nullable: true),
                    BHYT = table.Column<float>(type: "real", nullable: true),
                    HeSo = table.Column<float>(type: "real", nullable: true),
                    KhenThuongKyLuat = table.Column<float>(type: "real", nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    PhuCapChucVu = table.Column<float>(type: "real", nullable: true),
                    PhuCapTrinhDo = table.Column<float>(type: "real", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    ThucLinh = table.Column<float>(type: "real", nullable: true),
                    luong = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.MaLuong);
                });
        }
    }
}
