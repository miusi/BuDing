using BuDing.Domain.Entities;
using BuDing.Infrastructure.PageList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuDing.Application.Interfaces.BusinessLogic
{
	public interface ISysUserBusinessLogic
	{
		Task<SysUserEntity> GetSysUserById(int id);


		Task<SysUserEntity> Insert(SysUserEntity entity);

		Task<SysUserEntity> Update(SysUserEntity entity);

		Task Delete(SysUserEntity entity);

		Task<IPagedList<SysUserEntity>> GetPagedList(int pageIndex, int pageSize);

		Task<IPagedList<SysUserEntity>>  GetPagedListByUserName(string userName,int pageIndex,int pageSize);

	}
}
