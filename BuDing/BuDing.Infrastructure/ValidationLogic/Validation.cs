using BuDing.Infrastructure.ValidationLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.ValidationLogic
{
	public class Validation<TEntity> : IValidation<TEntity> where TEntity:class
	{
		private Dictionary<string, IValidationRule<TEntity>> _validationRules;

		public Validation()
		{
			_validationRules = new Dictionary<string, IValidationRule<TEntity>>();
		}

		protected virtual void AddRule(IValidationRule<TEntity> validationRule)
		{
			var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("N");
			_validationRules.Add(ruleName, validationRule);
		}

		protected virtual void RemoveRule(string ruleName)
		{
			_validationRules.Remove(ruleName);
		}

		public ValidationResult Valid(TEntity entity)
		{
			var result = new ValidationResult();
			foreach(var key in _validationRules.Keys)
			{
				var rule = _validationRules[key];
				if (!rule.Valid(entity))
					result.Add(rule.ErrorMessage);
			}

			return result;
		}
	}
}
