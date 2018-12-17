 
using BuDing.Domain.Entities; 
using BuDing.Infrastructure.DataLogic;
using System;  
using System.Text;
using System.Threading.Tasks;
using BuDing.Infrastructure.ValidationLogic;

namespace BuDing.Application.Services.Domain
{
    using BuDing.Application.Services.Stardand;

    public class SysUserLogic : ServiceBase<SysUserEntity>
	{
		public SysUserLogic(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
         
	}
}
