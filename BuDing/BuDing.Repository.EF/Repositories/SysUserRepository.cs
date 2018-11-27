

namespace BuDing.Repository.EF.Repositories
{
	using BuDing.Sunrise.Models;
	using BuDing.Infrustructure.EF;
	using BuDing.Repository.Contract;
	using BuDing.Repository.EF.Context;

	public class SysUserRepository : Repository<SysUser>, ISysUserRepository
	{
		public SysUserRepository(BuDingContext context) : base(context)
		{
		}
	}
}
