using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.ValidationLogic.Interfaces
{
	public interface ISelfValidation
	{
		ValidationResult ValidationResult { get; }

		bool IsValid { get; }
	}
}
