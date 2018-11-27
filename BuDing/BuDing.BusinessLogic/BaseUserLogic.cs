
using System; 

namespace BuDing.BusinessLogic
{
	using BuDing.Models;
	using BuDing.Infrustructure.BusinessLogic;
	using BuDing.Infrustructure.DataLogic;

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
