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
                    table.PrimaryKey("PK__ChucVu__D4639533225348B7", x => x.MaChucVu);
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
                    table.PrimaryKey("PK__ChuyenMo__9A6A23219205454B", x => x.MaChuyenMon);
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
                    table.PrimaryKey("PK__DanToc__A5FA0970D34914F9", x => x.MaDanToc);
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
                    table.PrimaryKey("PK__HeSo__0C16CD3D6D80D345", x => x.MaHeSo);
                });

            migrationBuilder.CreateTable(
                name: "LuongCoBan_PhanTramBH",
                columns: table => new
                {
                    MaLuongCoBan_PhanTramBH = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PhanTramBHYT = table.Column<double>(type: "float", nullable: true),
                    PhanTramBHTN = table.Column<double>(type: "float", nullable: true),
                    PhanTramBHXH = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LuongCoB__EDBBAA72C5AFCE92", x => x.MaLuongCoBan_PhanTramBH);
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
                    table.PrimaryKey("PK__LyDoKTKL__28E8B61EDE463E26", x => x.MaLyDo);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienDaNghiViec",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayVaoCongTy = table.Column<DateOnly>(type: "date", nullable: true),
                    MaDanToc = table.Column<int>(type: "int", nullable: true),
                    MaChucVu = table.Column<int>(type: "int", nullable: true),
                    MaPhongBan = table.Column<int>(type: "int", nullable: true),
                    MaTrinhDo = table.Column<int>(type: "int", nullable: true),
                    MaChuyenMon = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaHeSo = table.Column<int>(type: "int", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayNghiViec = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47D92B47D3", x => x.MaNhanVien);
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
                    table.PrimaryKey("PK__PhongBan__D0910CC8C4AAD809", x => x.MaPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    TenQuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quyen__1D4B7ED4C979A184", x => x.MaQuyen);
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
                    table.PrimaryKey("PK__TrinhDo__B64C90D36890B05F", x => x.MaTrinhDo);
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MaHeSo = table.Column<int>(type: "int", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47443858AA", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__NhanVien__MaChuc__59FA5E80",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaChuy__5CD6CB2B",
                        column: x => x.MaChuyenMon,
                        principalTable: "ChuyenMon",
                        principalColumn: "MaChuyenMon");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaDanT__59063A47",
                        column: x => x.MaDanToc,
                        principalTable: "DanToc",
                        principalColumn: "MaDanToc");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaHeSo__5DCAEF64",
                        column: x => x.MaHeSo,
                        principalTable: "HeSo",
                        principalColumn: "MaHeSo");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaPhon__5AEE82B9",
                        column: x => x.MaPhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "MaPhongBan");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaTrin__5BE2A6F2",
                        column: x => x.MaTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "MaTrinhDo");
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    ChamCongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    NgayGioVao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayGioRa = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChamCong__9D16AF613091FEAC", x => x.ChamCongID);
                    table.ForeignKey(
                        name: "FK__ChamCong__MaNhan__60A75C0F",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongKyLuat",
                columns: table => new
                {
                    MaKTKL = table.Column<int>(type: "int", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    LoaiKTKL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    MaLyDo = table.Column<int>(type: "int", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhenThuo__4019B956708EE729", x => x.MaKTKL);
                    table.ForeignKey(
                        name: "FK__KhenThuon__MaLyD__04E4BC85",
                        column: x => x.MaLyDo,
                        principalTable: "LyDoKTKL",
                        principalColumn: "MaLyDo");
                    table.ForeignKey(
                        name: "FK__KhenThuon__MaNha__03F0984C",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    userpassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaQuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserLogi__77B2CA4788CF4ED4", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__UserLogin__MaNha__59C55456",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                    table.ForeignKey(
                        name: "FK__UserLogin__MaQuy__5AB9788F",
                        column: x => x.MaQuyen,
                        principalTable: "Quyen",
                        principalColumn: "MaQuyen");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLuongCoBan_PhanTramBH = table.Column<int>(type: "int", nullable: true),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    MaKTKL = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Luong__6609A48D5AA62083", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK__Luong__MaKTKL__05D8E0BE",
                        column: x => x.MaKTKL,
                        principalTable: "KhenThuongKyLuat",
                        principalColumn: "MaKTKL");
                    table.ForeignKey(
                        name: "FK__Luong__MaLuongCo__6477ECF3",
                        column: x => x.MaLuongCoBan_PhanTramBH,
                        principalTable: "LuongCoBan_PhanTramBH",
                        principalColumn: "MaLuongCoBan_PhanTramBH");
                    table.ForeignKey(
                        name: "FK__Luong__MaNhanVie__6383C8BA",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_MaNhanVien",
                table: "ChamCong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_MaLyDo",
                table: "KhenThuongKyLuat",
                column: "MaLyDo");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_MaNhanVien",
                table: "KhenThuongKyLuat",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaKTKL",
                table: "Luong",
                column: "MaKTKL");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaLuongCoBan_PhanTramBH",
                table: "Luong",
                column: "MaLuongCoBan_PhanTramBH");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_MaQuyen",
                table: "UserLogin",
                column: "MaQuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NhanVienDaNghiViec");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "KhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "LuongCoBan_PhanTramBH");

            migrationBuilder.DropTable(
                name: "Quyen");

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
