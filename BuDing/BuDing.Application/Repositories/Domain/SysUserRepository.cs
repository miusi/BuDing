

namespace BuDing.Application.Repositories.Domain
{ 
    using BuDing.Domain.Entities;
    using BuDing.Application.Context;
    using BuDing.Application.Repositories.Standard;
    using BuDing.Application.Interfaces.IRepositories;

    public class SysUserRepository : RepositoryBase<SysUser>, ISysUserRepository
	{
		public SysUserRepository(BuDingContext context) : base(context)
		{
		}
	}
}
