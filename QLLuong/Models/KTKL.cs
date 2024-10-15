using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class KTKL
	{
		public string kTLKId { get; set; }
		[Required]
		public string staffId { get; set; }
		[Required]
		public string? loaiKTKL { get; set; }
		[Required]
		public DateTime? thangNam { get; set; }
		[Required]
		public string? lyDo { get; set; }
		[Required]
		public string? soTien { get; set; }
	}
}
