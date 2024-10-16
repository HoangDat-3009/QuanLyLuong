using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class Luong
	{
		[Key]
		public int MaLuong  { get; set; }

		public int MaNhanVien  { get; set; }
		public int? Thang { get; set; }
		public int? Nam { get; set; }

		public float? HeSo { get; set; }

		public float? luong { get; set; }
		public float? PhuCapChucVu { get; set; }
		public float? PhuCapTrinhDo { get; set; }
		public float? BHYT { get; set; }
		public float? BHTN { get; set; }
		public float? BHXH { get; set; }
		public float? KhenThuongKyLuat { get; set; }
		public float? ThucLinh { get; set; }
	}
}
