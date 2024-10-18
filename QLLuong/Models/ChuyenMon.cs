using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class ChuyenMon
	{
		[Key]
		public int MaChuyenMon { get; set; }
		public string? TenChuyenMon { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
