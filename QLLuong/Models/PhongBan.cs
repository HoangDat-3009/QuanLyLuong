using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
    public class PhongBan
    {
        [Key]
        public int MaPhongBan { get; set; }
        public string? TenPhongBan { get; set; }
        public string? DienThoai { get; set; }
    }
}
