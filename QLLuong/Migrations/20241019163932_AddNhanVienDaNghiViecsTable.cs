using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLLuong.Migrations
{
    /// <inheritdoc />
    public partial class AddNhanVienDaNghiViecsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanVienDaNghiViecs",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateOnly>(nullable: true),
                    NoiSinh = table.Column<string>(nullable: true),
                    NgayNghiViec = table.Column<DateTime>(nullable: false),
                    NgayVaoCongTy = table.Column<DateOnly>(nullable: true),
                    MaDanToc = table.Column<int>(nullable: true),
                    MaChucVu = table.Column<int>(nullable: true),
                    MaPhongBan = table.Column<int>(nullable: true),
                    MaTrinhDo = table.Column<int>(nullable: true),
                    MaChuyenMon = table.Column<int>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    MaHeSo = table.Column<int>(nullable: true),
                    Cccd = table.Column<string>(nullable: true),
                    TaiKhoanNganHang = table.Column<string>(nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienDaNghiViecs", x => x.MaNhanVien);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVienDaNghiViecs");
        }
    }

}
