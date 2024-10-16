using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class KTKL
	{
		[Key]
        public int MaKTKL { get; set; }
		public int? MaNhanVien { get; set; }
		public string? LoaiKTKL { get; set; }
		public int? Thang { get; set; }
		public int? Nam { get; set; }
		public int? MaLyDo { get; set; }
		public string? SoTien { get; set; }
	}
}
