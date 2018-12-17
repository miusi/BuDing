

namespace BuDing.Application.Interfaces.Services
{
	using BuDing.Domain.Entities;
	using BuDing.Infrastructure.Utilities;
	using BuDing.Infrastructure.DataService;
	using BuDing.Application.Interfaces.PageList;

	public interface ISysUserService:IService<SysUserEntity>
    {
		BaseResult Login(string username, string password);

		IPagedList<SysUserEntity> GetPagedList(int pageIndex, int pageSize);

        IPagedList<SysUserEntity> GetPagedListByUserName(string userName, int pageIndex, int pageSize);

    }
}
