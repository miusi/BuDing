using BuDing.Infrastructure.Specification.Interfaces;
using BuDing.Infrastructure.ValidationLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.ValidationLogic
{
	public class ValidationRule<TEntity> : IValidationRule<TEntity>
	{
		private ISpecification<TEntity> _specificationRule;

		public ValidationRule(ISpecification<TEntity> specificationRule,string errorMessage)
		{
			_specificationRule = specificationRule;
			ErrorMessage = errorMessage;
		}

		public string ErrorMessage { get; private set; }

		public bool Valid(TEntity entity)
		{
			return _specificationRule.IsSatisfiedBy(entity);
		}
	}
}
