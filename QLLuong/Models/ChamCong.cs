using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLLuong.Models
{
    [Table("ChamCong")]
    public class ChamCong
    {
        [Key]
        public int? MaNhanVien { get; set; }
        [Required]
        public DateTime? NgayGioVao { get; set; }
        [Required]
        public DateTime? NgayGioRa { get; set; }

        [Required]
        public string? TrangThai { get; set; }
        [Required]
        public string? GhiChu { get; set; }

    }
}
