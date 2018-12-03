using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.ValidationLogic.Interfaces
{
	public interface IValidation<TEntity>
	{
		ValidationResult Valid(TEntity entity);
	}
}
