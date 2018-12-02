 
using BuDing.Application.Services.Stardand;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.BusinessLogic;
using BuDing.Infrastructure.DataLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Application.Services.Domain
{
	public class SysUserLogic : DataService<SysUserEntity>
	{
		public SysUserLogic(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
