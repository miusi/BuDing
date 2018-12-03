using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.ValidationLogic.Interfaces
{
	public interface IValidationRule<TEntity>
	{
		string ErrorMessage { get; }
		bool Valid(TEntity entity);
	}
}
