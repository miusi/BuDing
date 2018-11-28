 


namespace BuDing.Application.Context
{
    using BuDing.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class BuDingContext:DbContext
	{
		public BuDingContext(DbContextOptions<BuDingContext> options)
		  : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SysUser>().ToTable("sys_user");
			modelBuilder.Entity<SysRole>().ToTable("sys_role");
		}
	}
}
