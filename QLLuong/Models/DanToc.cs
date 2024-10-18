using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
	public class DanToc
	{
		[Key]
		public int MaDanToc { get; set; }
		public string? TenDanToc { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
