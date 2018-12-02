using System;
using System.Collections.Generic;
using System.Text;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.DataService;

namespace BuDing.Application.Interfaces.Services
{
    interface ISysUserDataService:IDataService<SysUserEntity>
    {
    }
}
