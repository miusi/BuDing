using System;
using System.Collections.Generic;
using System.Text;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.DataService;
using BuDing.Infrastructure.PageList;

namespace BuDing.Application.Interfaces.Services
{
    public interface ISysUserDataService:IService<SysUserEntity>
    {
        IPagedList<SysUserEntity> GetPagedList(int pageIndex, int pageSize);

        IPagedList<SysUserEntity> GetPagedListByUserName(string userName, int pageIndex, int pageSize);

    }
}
