using System;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
    public class NhanVienDaNghiViec
    {
        [Key]
        public int MaNhanVien { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateOnly? NgaySinh { get; set; }
        public string? NoiSinh { get; set; }
        public DateOnly? NgayVaoCongTy { get; set; }
        public int? MaDanToc { get; set; }
        public int? MaChucVu { get; set; }
        public int? MaPhongBan { get; set; }
        public int? MaTrinhDo { get; set; }
        public int? MaChuyenMon { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public int? MaHeSo { get; set; }
        public string? Cccd { get; set; }
        public string? TaiKhoanNganHang { get; set; }
        public string? SoTaiKhoanNganHang { get; set; }
        public DateTime NgayNghiViec { get; set; } = DateTime.Now;
    }
}
