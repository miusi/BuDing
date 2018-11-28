using System;

namespace BuDing.Application.Services.Domain
{
    using BuDing.Domain.Entities;
    using BuDing.Infrastructure.DataLogic;
    using BuDing.Infrastructure.BusinessLogic;
    using BuDing.Application.Services.Standard;

    public class BaseUserLogic : BaseBusinessLogic<BaseUser>, IBusinessLogic<BaseUser>
	{
		public BaseUserLogic(IRepository<BaseUser> repository) : base(repository)
		{
		}

		public override bool Validate(BaseUser entityToValidate)
		{
			throw new NotImplementedException();
		}
	}
}
