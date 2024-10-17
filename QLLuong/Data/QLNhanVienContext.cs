using Microsoft.EntityFrameworkCore;
using QLLuong.Models;
using System;

namespace QLLuong.Data
{
    public class QLNhanVienContext : DbContext
    {
        public QLNhanVienContext(DbContextOptions<QLNhanVienContext> options) : base(options)
        {
        }
        public DbSet<QLLuong.Models.UserLogin> UserLogins { get; set; }
        public DbSet<QLLuong.Models.ChamCong> ChamCong { get; set; }
        public DbSet<QLLuong.Models.NhanVien> NhanViens { get; set; }
        
    }
}
