using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class HeSo
	{
		[Key]
		public int MaHeSo { get; set; }
		public float? HeSoLuong { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
