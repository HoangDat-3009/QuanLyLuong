using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class ChucVu
	{
		[Key]
		public int MaChucVu { get; set; }
		public string? TenChucVu { get; set; }
		public decimal PhuCap { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
