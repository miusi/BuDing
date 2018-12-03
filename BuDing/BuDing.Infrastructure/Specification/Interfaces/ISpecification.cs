using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.Specification.Interfaces
{
	/// <summary>
	/// 规范
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface ISpecification<TEntity>
	{
		bool IsSatisfiedBy(TEntity entity);
	}
}
