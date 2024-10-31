using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLLuong.Migrations
{
    /// <inheritdoc />
    public partial class ConfigMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ChamCong__MaNhan__60A75C0F",
                table: "ChamCong");

            migrationBuilder.DropForeignKey(
                name: "FK__KhenThuon__MaLyD__04E4BC85",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropForeignKey(
                name: "FK__KhenThuon__MaNha__03F0984C",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaKTKL__05D8E0BE",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaLuongCo__6477ECF3",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaNhanVie__6383C8BA",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaChuc__59FA5E80",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaChuy__5CD6CB2B",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaDanT__59063A47",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaHeSo__5DCAEF64",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaPhon__5AEE82B9",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaTrin__5BE2A6F2",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__UserLogin__MaNha__59C55456",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK__UserLogin__MaQuy__5AB9788F",
                table: "UserLogin");

            migrationBuilder.DropTable(
                name: "NhanVienDaNghiViec");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserLogi__77B2CA4788CF4ED4",
                table: "UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK__TrinhDo__B64C90D36890B05F",
                table: "TrinhDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Quyen__1D4B7ED4C979A184",
                table: "Quyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PhongBan__D0910CC8C4AAD809",
                table: "PhongBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NhanVien__77B2CA47443858AA",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LyDoKTKL__28E8B61EDE463E26",
                table: "LyDoKTKL");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LuongCoB__EDBBAA72C5AFCE92",
                table: "LuongCoBan_PhanTramBH");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Luong__6609A48D5AA62083",
                table: "Luong");

            migrationBuilder.DropPrimaryKey(
                name: "PK__KhenThuo__4019B956708EE729",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropPrimaryKey(
                name: "PK__HeSo__0C16CD3D6D80D345",
                table: "HeSo");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DanToc__A5FA0970D34914F9",
                table: "DanToc");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChuyenMo__9A6A23219205454B",
                table: "ChuyenMon");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChucVu__D4639533225348B7",
                table: "ChucVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChamCong__9D16AF613091FEAC",
                table: "ChamCong");

            migrationBuilder.AlterColumn<string>(
                name: "TaiKhoanNganHang",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SoTaiKhoanNganHang",
                table: "NhanVien",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiSinh",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "NgaySinh",
                table: "NhanVien",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GioiTinh",
                table: "NhanVien",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "NhanVien",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NhanVien",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "NhanVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaNhanVien",
                table: "ChamCong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserLogi__77B2CA47EA39A939",
                table: "UserLogin",
                column: "MaNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TrinhDo__B64C90D3DFA8268D",
                table: "TrinhDo",
                column: "MaTrinhDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Quyen__1D4B7ED488D5E85F",
                table: "Quyen",
                column: "MaQuyen");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PhongBan__D0910CC85F4E30D4",
                table: "PhongBan",
                column: "MaPhongBan");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NhanVien__77B2CA47EFA648BE",
                table: "NhanVien",
                column: "MaNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LyDoKTKL__28E8B61E52A5F6D5",
                table: "LyDoKTKL",
                column: "MaLyDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LuongCoB__EDBBAA727F8BBC55",
                table: "LuongCoBan_PhanTramBH",
                column: "MaLuongCoBan_PhanTramBH");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Luong__6609A48D34E6B263",
                table: "Luong",
                column: "MaLuong");

            migrationBuilder.AddPrimaryKey(
                name: "PK__KhenThuo__4019B9562F09916A",
                table: "KhenThuongKyLuat",
                column: "MaKTKL");

            migrationBuilder.AddPrimaryKey(
                name: "PK__HeSo__0C16CD3D0B98CCCE",
                table: "HeSo",
                column: "MaHeSo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DanToc__A5FA09701FB4C3D8",
                table: "DanToc",
                column: "MaDanToc");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChuyenMo__9A6A232125687042",
                table: "ChuyenMon",
                column: "MaChuyenMon");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChucVu__D46395331BE380FA",
                table: "ChucVu",
                column: "MaChucVu");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChamCong__9D16AF61FF33F476",
                table: "ChamCong",
                column: "ChamCongID");

            migrationBuilder.CreateTable(
                name: "LuongCu",
                columns: table => new
                {
                    MaLuongCu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: true),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    HeSo = table.Column<double>(type: "float", nullable: true),
                    PhuCapChucVu = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PhuCapTrinhDo = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    BHYT = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    BHTN = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    BHXH = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    KhenThuongKyLuat = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoCong = table.Column<int>(type: "int", nullable: true),
                    ThucLinh = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LuongCu__A3152324ECD8EBFA", x => x.MaLuongCu);
                    table.ForeignKey(
                        name: "FK__LuongCu__MaNhanV__72C60C4A",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LuongCu_MaNhanVien",
                table: "LuongCu",
                column: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__ChamCong__MaNhan__619B8048",
                table: "ChamCong",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__KhenThuon__MaLyD__656C112C",
                table: "KhenThuongKyLuat",
                column: "MaLyDo",
                principalTable: "LyDoKTKL",
                principalColumn: "MaLyDo");

            migrationBuilder.AddForeignKey(
                name: "FK__KhenThuon__MaNha__6477ECF3",
                table: "KhenThuongKyLuat",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaKTKL__68487DD7",
                table: "Luong",
                column: "MaKTKL",
                principalTable: "KhenThuongKyLuat",
                principalColumn: "MaKTKL");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaLuongCo__6A30C649",
                table: "Luong",
                column: "MaLuongCoBan_PhanTramBH",
                principalTable: "LuongCoBan_PhanTramBH",
                principalColumn: "MaLuongCoBan_PhanTramBH");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaNhanVie__693CA210",
                table: "Luong",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaChuc__5AEE82B9",
                table: "NhanVien",
                column: "MaChucVu",
                principalTable: "ChucVu",
                principalColumn: "MaChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaChuy__5DCAEF64",
                table: "NhanVien",
                column: "MaChuyenMon",
                principalTable: "ChuyenMon",
                principalColumn: "MaChuyenMon");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaDanT__59FA5E80",
                table: "NhanVien",
                column: "MaDanToc",
                principalTable: "DanToc",
                principalColumn: "MaDanToc");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaHeSo__5EBF139D",
                table: "NhanVien",
                column: "MaHeSo",
                principalTable: "HeSo",
                principalColumn: "MaHeSo");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaPhon__5BE2A6F2",
                table: "NhanVien",
                column: "MaPhongBan",
                principalTable: "PhongBan",
                principalColumn: "MaPhongBan");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaTrin__5CD6CB2B",
                table: "NhanVien",
                column: "MaTrinhDo",
                principalTable: "TrinhDo",
                principalColumn: "MaTrinhDo");

            migrationBuilder.AddForeignKey(
                name: "FK__UserLogin__MaNha__6EF57B66",
                table: "UserLogin",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__UserLogin__MaQuy__6FE99F9F",
                table: "UserLogin",
                column: "MaQuyen",
                principalTable: "Quyen",
                principalColumn: "MaQuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ChamCong__MaNhan__619B8048",
                table: "ChamCong");

            migrationBuilder.DropForeignKey(
                name: "FK__KhenThuon__MaLyD__656C112C",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropForeignKey(
                name: "FK__KhenThuon__MaNha__6477ECF3",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaKTKL__68487DD7",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaLuongCo__6A30C649",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__Luong__MaNhanVie__693CA210",
                table: "Luong");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaChuc__5AEE82B9",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaChuy__5DCAEF64",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaDanT__59FA5E80",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaHeSo__5EBF139D",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaPhon__5BE2A6F2",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__NhanVien__MaTrin__5CD6CB2B",
                table: "NhanVien");

            migrationBuilder.DropForeignKey(
                name: "FK__UserLogin__MaNha__6EF57B66",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK__UserLogin__MaQuy__6FE99F9F",
                table: "UserLogin");

            migrationBuilder.DropTable(
                name: "LuongCu");

            migrationBuilder.DropPrimaryKey(
                name: "PK__UserLogi__77B2CA47EA39A939",
                table: "UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK__TrinhDo__B64C90D3DFA8268D",
                table: "TrinhDo");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Quyen__1D4B7ED488D5E85F",
                table: "Quyen");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PhongBan__D0910CC85F4E30D4",
                table: "PhongBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK__NhanVien__77B2CA47EFA648BE",
                table: "NhanVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LyDoKTKL__28E8B61E52A5F6D5",
                table: "LyDoKTKL");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LuongCoB__EDBBAA727F8BBC55",
                table: "LuongCoBan_PhanTramBH");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Luong__6609A48D34E6B263",
                table: "Luong");

            migrationBuilder.DropPrimaryKey(
                name: "PK__KhenThuo__4019B9562F09916A",
                table: "KhenThuongKyLuat");

            migrationBuilder.DropPrimaryKey(
                name: "PK__HeSo__0C16CD3D0B98CCCE",
                table: "HeSo");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DanToc__A5FA09701FB4C3D8",
                table: "DanToc");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChuyenMo__9A6A232125687042",
                table: "ChuyenMon");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChucVu__D46395331BE380FA",
                table: "ChucVu");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ChamCong__9D16AF61FF33F476",
                table: "ChamCong");

            migrationBuilder.AlterColumn<string>(
                name: "TaiKhoanNganHang",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SoTaiKhoanNganHang",
                table: "NhanVien",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NoiSinh",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "NgaySinh",
                table: "NhanVien",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "NhanVien",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GioiTinh",
                table: "NhanVien",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "DienThoai",
                table: "NhanVien",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NhanVien",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "NhanVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "MaNhanVien",
                table: "ChamCong",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__UserLogi__77B2CA4788CF4ED4",
                table: "UserLogin",
                column: "MaNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK__TrinhDo__B64C90D36890B05F",
                table: "TrinhDo",
                column: "MaTrinhDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Quyen__1D4B7ED4C979A184",
                table: "Quyen",
                column: "MaQuyen");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PhongBan__D0910CC8C4AAD809",
                table: "PhongBan",
                column: "MaPhongBan");

            migrationBuilder.AddPrimaryKey(
                name: "PK__NhanVien__77B2CA47443858AA",
                table: "NhanVien",
                column: "MaNhanVien");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LyDoKTKL__28E8B61EDE463E26",
                table: "LyDoKTKL",
                column: "MaLyDo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__LuongCoB__EDBBAA72C5AFCE92",
                table: "LuongCoBan_PhanTramBH",
                column: "MaLuongCoBan_PhanTramBH");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Luong__6609A48D5AA62083",
                table: "Luong",
                column: "MaLuong");

            migrationBuilder.AddPrimaryKey(
                name: "PK__KhenThuo__4019B956708EE729",
                table: "KhenThuongKyLuat",
                column: "MaKTKL");

            migrationBuilder.AddPrimaryKey(
                name: "PK__HeSo__0C16CD3D6D80D345",
                table: "HeSo",
                column: "MaHeSo");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DanToc__A5FA0970D34914F9",
                table: "DanToc",
                column: "MaDanToc");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChuyenMo__9A6A23219205454B",
                table: "ChuyenMon",
                column: "MaChuyenMon");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChucVu__D4639533225348B7",
                table: "ChucVu",
                column: "MaChucVu");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ChamCong__9D16AF613091FEAC",
                table: "ChamCong",
                column: "ChamCongID");

            migrationBuilder.CreateTable(
                name: "NhanVienDaNghiViec",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    Cccd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaChucVu = table.Column<int>(type: "int", nullable: true),
                    MaChuyenMon = table.Column<int>(type: "int", nullable: true),
                    MaDanToc = table.Column<int>(type: "int", nullable: true),
                    MaHeSo = table.Column<int>(type: "int", nullable: true),
                    MaPhongBan = table.Column<int>(type: "int", nullable: true),
                    MaTrinhDo = table.Column<int>(type: "int", nullable: true),
                    NgayNghiViec = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayVaoCongTy = table.Column<DateOnly>(type: "date", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoTaiKhoanNganHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaiKhoanNganHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47D92B47D3", x => x.MaNhanVien);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__ChamCong__MaNhan__60A75C0F",
                table: "ChamCong",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__KhenThuon__MaLyD__04E4BC85",
                table: "KhenThuongKyLuat",
                column: "MaLyDo",
                principalTable: "LyDoKTKL",
                principalColumn: "MaLyDo");

            migrationBuilder.AddForeignKey(
                name: "FK__KhenThuon__MaNha__03F0984C",
                table: "KhenThuongKyLuat",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaKTKL__05D8E0BE",
                table: "Luong",
                column: "MaKTKL",
                principalTable: "KhenThuongKyLuat",
                principalColumn: "MaKTKL");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaLuongCo__6477ECF3",
                table: "Luong",
                column: "MaLuongCoBan_PhanTramBH",
                principalTable: "LuongCoBan_PhanTramBH",
                principalColumn: "MaLuongCoBan_PhanTramBH");

            migrationBuilder.AddForeignKey(
                name: "FK__Luong__MaNhanVie__6383C8BA",
                table: "Luong",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaChuc__59FA5E80",
                table: "NhanVien",
                column: "MaChucVu",
                principalTable: "ChucVu",
                principalColumn: "MaChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaChuy__5CD6CB2B",
                table: "NhanVien",
                column: "MaChuyenMon",
                principalTable: "ChuyenMon",
                principalColumn: "MaChuyenMon");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaDanT__59063A47",
                table: "NhanVien",
                column: "MaDanToc",
                principalTable: "DanToc",
                principalColumn: "MaDanToc");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaHeSo__5DCAEF64",
                table: "NhanVien",
                column: "MaHeSo",
                principalTable: "HeSo",
                principalColumn: "MaHeSo");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaPhon__5AEE82B9",
                table: "NhanVien",
                column: "MaPhongBan",
                principalTable: "PhongBan",
                principalColumn: "MaPhongBan");

            migrationBuilder.AddForeignKey(
                name: "FK__NhanVien__MaTrin__5BE2A6F2",
                table: "NhanVien",
                column: "MaTrinhDo",
                principalTable: "TrinhDo",
                principalColumn: "MaTrinhDo");

            migrationBuilder.AddForeignKey(
                name: "FK__UserLogin__MaNha__59C55456",
                table: "UserLogin",
                column: "MaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK__UserLogin__MaQuy__5AB9788F",
                table: "UserLogin",
                column: "MaQuyen",
                principalTable: "Quyen",
                principalColumn: "MaQuyen");
        }
    }
}
