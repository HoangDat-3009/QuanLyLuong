using Microsoft.EntityFrameworkCore;

namespace QLLuong.Data
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext(DbContextOptions<QLLuongContext> options)
            : base(options)
        {
        }

        public DbSet<QLLuong.Models.NhanVien> NhanVien { get; set; }
        public DbSet<QLLuong.Models.Luong> Luong { get; set; }
        public DbSet<QLLuong.Models.KTKL> KTKL { get; set; }
    }
}
