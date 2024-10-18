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
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<int>(type: "int", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhuCap = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChucVu__D463953359346141", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenMon",
                columns: table => new
                {
                    MaChuyenMon = table.Column<int>(type: "int", nullable: false),
                    TenChuyenMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChuyenMo__9A6A23216EA0151C", x => x.MaChuyenMon);
                });

            migrationBuilder.CreateTable(
                name: "DanToc",
                columns: table => new
                {
                    MaDanToc = table.Column<int>(type: "int", nullable: false),
                    TenDanToc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanToc__A5FA0970C9E0330F", x => x.MaDanToc);
                });

            migrationBuilder.CreateTable(
                name: "HeSo",
                columns: table => new
                {
                    MaHeSo = table.Column<int>(type: "int", nullable: false),
                    HeSoLuong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HeSo__0C16CD3DDACDE2E9", x => x.MaHeSo);
                });

            migrationBuilder.CreateTable(
                name: "LuongCoBan",
                columns: table => new
                {
                    MaLuongCoBan = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LuongCoB__542BDA5FA898E9B5", x => x.MaLuongCoBan);
                });

            migrationBuilder.CreateTable(
                name: "LyDoKTKL",
                columns: table => new
                {
                    MaLyDo = table.Column<int>(type: "int", nullable: false),
                    TenLyDo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LyDoKTKL__28E8B61E81D03FA8", x => x.MaLyDo);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    MaPhongBan = table.Column<int>(type: "int", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhongBan__D0910CC8CDCC7106", x => x.MaPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDo",
                columns: table => new
                {
                    MaTrinhDo = table.Column<int>(type: "int", nullable: false),
                    TenTrinhDo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhuCap = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrinhDo__B64C90D359CB8978", x => x.MaTrinhDo);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userpassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserLogi__3213E83FF4866A6C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayVaoCongTy = table.Column<DateOnly>(type: "date", nullable: true),
                    MaDanToc = table.Column<int>(type: "int", nullable: true),
                    MaChucVu = table.Column<int>(type: "int", nullable: true),
                    MaPhongBan = table.Column<int>(type: "int", nullable: true),
                    MaTrinhDo = table.Column<int>(type: "int", nullable: true),
                    MaChuyenMon = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MaHeSo = table.Column<int>(type: "int", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA4773660A31", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__NhanVien__MaChuc__619B8048",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaChuy__6477ECF3",
                        column: x => x.MaChuyenMon,
                        principalTable: "ChuyenMon",
                        principalColumn: "MaChuyenMon");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaDanT__60A75C0F",
                        column: x => x.MaDanToc,
                        principalTable: "DanToc",
                        principalColumn: "MaDanToc");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaHeSo__656C112C",
                        column: x => x.MaHeSo,
                        principalTable: "HeSo",
                        principalColumn: "MaHeSo");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaPhon__628FA481",
                        column: x => x.MaPhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "MaPhongBan");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaTrin__6383C8BA",
                        column: x => x.MaTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "MaTrinhDo");
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    ChamCongId = table.Column<int>(type: "int", nullable: false),
                    NgayGioVao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayGioRa = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__ChamCong__MaNhan__6754599E",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongKyLuat",
                columns: table => new
                {
                    MaKTKL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    LoaiKTKL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    MaLyDo = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuongKyLuat", x => x.MaKTKL);
                    table.ForeignKey(
                        name: "FK__KhenThuon__MaLyD__6D0D32F4",
                        column: x => x.MaLyDo,
                        principalTable: "LyDoKTKL",
                        principalColumn: "MaLyDo");
                    table.ForeignKey(
                        name: "FK__KhenThuon__MaNha__6C190EBB",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    HeSo = table.Column<double>(type: "float", nullable: true),
                    Luong = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PhuCapChucVu = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PhuCapTrinhDo = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    BHYT = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    BHTN = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    BHXH = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    KhenThuongKyLuat = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ThucLinh = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Luong__6609A48D03F257E2", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK__Luong__MaNhanVie__6A30C649",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_MaLyDo",
                table: "KhenThuongKyLuat",
                column: "MaLyDo");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_MaNhanVien",
                table: "KhenThuongKyLuat",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaNhanVien",
                table: "Luong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChuyenMon",
                table: "NhanVien",
                column: "MaChuyenMon");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaDanToc",
                table: "NhanVien",
                column: "MaDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaHeSo",
                table: "NhanVien",
                column: "MaHeSo");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaPhongBan",
                table: "NhanVien",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaTrinhDo",
                table: "NhanVien",
                column: "MaTrinhDo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "KhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "LuongCoBan");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "LyDoKTKL");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "ChuyenMon");

            migrationBuilder.DropTable(
                name: "DanToc");

            migrationBuilder.DropTable(
                name: "HeSo");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "TrinhDo");
        }
    }
}
