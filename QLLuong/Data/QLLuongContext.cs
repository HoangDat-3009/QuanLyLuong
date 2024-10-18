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

		public virtual DbSet<NhanVien> NhanVien { get; set; }
		public virtual DbSet<PhongBan> PhongBan { get; set; }
		public virtual DbSet<ChucVu> ChucVu { get; set; }
		public virtual DbSet<ChuyenMon> ChuyenMon { get; set; }
		public virtual DbSet<HeSo> HeSo { get; set; }
		public virtual DbSet<DanToc> DanToc { get; set; }
		public virtual DbSet<TrinhDo> TrinhDo { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NhanVien>().ToTable(nameof(NhanVien));
			modelBuilder.Entity<PhongBan>().ToTable(nameof(PhongBan));
			modelBuilder.Entity<ChucVu>().ToTable(nameof(ChucVu));
			modelBuilder.Entity<ChuyenMon>().ToTable(nameof(ChuyenMon));
			modelBuilder.Entity<HeSo>().ToTable(nameof(HeSo));
			modelBuilder.Entity<DanToc>().ToTable(nameof(DanToc));
			modelBuilder.Entity<TrinhDo>().ToTable(nameof(TrinhDo));
		}
	}
}
