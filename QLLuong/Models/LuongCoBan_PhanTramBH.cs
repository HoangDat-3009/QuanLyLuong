using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models
{
    public class LuongCoBan_PhanTramBH
    {
        [Key]
        public int MaLuongCoBan_PhanTramBH {  get; set; }
        public decimal LuongCoBan {  get; set; }
        public float PhanTramBHYT { get; set; }
        public float PhanTramBHTN { get; set; }
        public float PhanTramBHXH { get; set; }
        public virtual ICollection<Luong> Luongs { get; set; } = new List<Luong>();
    }
}
