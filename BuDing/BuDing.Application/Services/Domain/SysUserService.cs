
using BuDing.Application.Interfaces.Services;
using BuDing.Application.Services.Stardand;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.BusinessLogic;
using BuDing.Infrastructure.DataLogic;
using BuDing.Infrastructure.PageList;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Application.Services.Domain
{
	public class SysUserService : DataService<SysUserEntity>,ISysUserDataService
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
