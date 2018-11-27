using BuDing.Sunrise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Repository.EF.Context
{
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
