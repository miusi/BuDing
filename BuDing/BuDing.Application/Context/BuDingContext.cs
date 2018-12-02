 


using BuDing.Domain.Configurations;

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

        public DbSet<SysUserEntity> SysUsers { get; set; }

        public DbSet<SysRoleEntity> SysRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
		    modelBuilder.ApplyConfiguration<SysUserEntity>(new SysUserConfiguration());
		    modelBuilder.ApplyConfiguration<SysRoleEntity>(new SysRoleConfiguration());
		}
	}
}
