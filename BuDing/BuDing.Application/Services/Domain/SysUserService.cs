﻿

namespace BuDing.Application.Services.Domain
{
	using BuDing.Domain.Entities; 
	using BuDing.Infrastructure.DataLogic;
	using BuDing.Application.Services.Stardand;
	using BuDing.Application.Interfaces.Services;
	using BuDing.Application.Interfaces.PageList;

	public class SysUserService : ServiceBase<SysUserEntity>,ISysUserService
	{
		public SysUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

        public IPagedList<SysUserEntity> GetPagedList(int pageIndex, int pageSize)
        {
            return _repository.GetEnumerable().ToPagedList<SysUserEntity>(pageIndex, pageSize);
        }

        public IPagedList<SysUserEntity> GetPagedListByUserName(string userName, int pageIndex, int pageSize)
        {
            return _repository.GetEnumerable(t => t.Name == userName).ToPagedList<SysUserEntity>(pageIndex, pageSize);
        }
    }
}
