using Microsoft.EntityFrameworkCore;
using QLLuong.Models;

namespace QLLuong.Data
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext(DbContextOptions<QLLuongContext> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }

    }
}
