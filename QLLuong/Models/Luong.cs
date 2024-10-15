using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class Luong
	{

		private string luongId { get; set; }
		[Required]

		private string? staffId { get; set; }
		[Required]
		private DateTime? createdDate { get; set; }
		[Required]

		private float? heSoLuong { get; set; }
		[Required]
		[Range(0.1, 10.0)]

		private float? luongCoBan { get; set; }
		[Required]
		private float? phuCapTrinhDo { get; set; }
		[Required]
		private float? phuCapChucVu { get; set; }
		[Required]
		private float? bHYT { get; set; }
		[Required]
		private float? bHXH { get; set; }
		[Required]
		private float? KTKL { get; set; }
		[Required]
		private float? thucLinh { get; set; }
	}
}
