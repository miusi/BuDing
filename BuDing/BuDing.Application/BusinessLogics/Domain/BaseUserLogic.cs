using System;
using BuDing.Application.Services.Standard;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.BusinessLogic;
using BuDing.Infrastructure.DataLogic;

namespace BuDing.Application.BusinessLogics.Domain
{
    public class BaseUserLogic : BaseBusinessLogic<BaseUserEntity>, IBusinessLogic<BaseUserEntity>
	{
		public BaseUserLogic(IRepository<BaseUserEntity> repository) : base(repository)
		{
		}

		public override bool Validate(BaseUserEntity entityToValidate)
		{
			throw new NotImplementedException();
		}
	}
}
