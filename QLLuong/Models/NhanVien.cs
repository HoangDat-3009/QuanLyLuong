using System.ComponentModel.DataAnnotations;
namespace QLLuong.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }
        [Required]
        public string? HoTen { get; set; }
        [Required]
        public string? GioiTinh { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        public string? NoiSinh { get; set; }
        [Required]
        public int? MaDanToc { get; set; }
        [Required]
        public int? MaChucVu { get; set; }
        [Required]
        public int? MaPhongBan { get; set; }
        [Required]
        public int? MaTrinhDo { get; set; }
        [Required]
        public int? MaChuyenMon { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        [Required]
        public string? DienThoai { get; set; }
        [Required]
        public int? MaHeSo { get; set; }
    }
}
