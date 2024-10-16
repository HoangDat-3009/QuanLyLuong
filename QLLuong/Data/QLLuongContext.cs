using Microsoft.EntityFrameworkCore;

namespace QLLuong.Data
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext(DbContextOptions<QLLuongContext> options)
            : base(options)
        {
        }

        public DbSet<QLLuong.Models.NhanVien> NhanViens { get; set; }
        public DbSet<QLLuong.Models.Luong> Luongs { get; set; }
        public DbSet<QLLuong.Models.KTKL> KTKLs { get; set; }
    }
}
