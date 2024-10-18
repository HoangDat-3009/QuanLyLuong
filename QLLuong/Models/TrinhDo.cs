using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class TrinhDo
	{
		[Key]
		public int MaTrinhDo { get; set; }
		public string? TenTrinhDo { get; set; }
		public decimal PhuCap { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
