using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class Luong
	{

		private int MaLuong  { get; set; }

		private int MaNhanVien  { get; set; }
		private int? Thang { get; set; }
		private int? Nam { get; set; }

		private float? HeSo { get; set; }

		private float? luong { get; set; }
		private float? PhuCapChucVu { get; set; }
		private float? PhuCapTrinhDo { get; set; }
		private float? BHYT { get; set; }
		private float? BHTN { get; set; }
		private float? BHXH { get; set; }
		private float? KhenThuongKyLuat { get; set; }
		private float? ThucLinh { get; set; }
	}
}
