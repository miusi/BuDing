//-----------------------------------------------------------------------
// <copyright file="ValidationResult.cs">
// * Copyright (C) 2018 Godric All Rights Reserved
// * version : 4.0.30319.42000 
// * FileName: ValidationResult.cs 
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using System.Collections.Generic;

namespace BuDing.Infrastructure.ValidationLogic
{
    /// <summary>
    /// ValidationResult
    /// 验证结果
    /// 
    /// 修改纪录
    ///   
    ///	2018-11-23 版本：1.0 Godric 创建文件。
    ///		
    /// <author>
    ///	<name>Godric</name>
    ///	<date>2018-07-23</date>
    /// </author> 
    /// </summary>

    public class ValidationResult
	{
        /// <summary>
        /// 错误集
        /// </summary>
		private List<ValidationError> _errors;

        /// <summary>
        /// Message
        /// </summary>
		private string Message { get; set; }

        /// <summary>
        /// 是否通过验证
        /// </summary>
		public bool IsValid { get { return !_errors.Any(); } }

        /// <summary>
        /// 异常结果
        /// </summary>
		public IEnumerable<ValidationError> Errors { get { return _errors; } }

        /// <summary>
        /// cotr
        /// </summary>
		public ValidationResult()
		{
			_errors = new List<ValidationError>();
		}

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="errorMessage">错误信息</param>
        /// <returns></returns>
		public ValidationResult Add(string errorMessage)
		{
			_errors.Add(new ValidationError(errorMessage));
			return this;
		}

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="error">验证错误信息</param>
        /// <returns></returns>
		public ValidationResult Add(ValidationError error)
		{
			_errors.Add(error);
			return this;
		}

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="validationResults">验证错误信息</param>
        /// <returns></returns>
		public ValidationResult Add(params ValidationResult[] validationResults)
		{
			if (validationResults == null) return this;

			foreach (var result in validationResults.Where(r => r != null))
				_errors.AddRange(result.Errors);

			return this;
		}

        /// <summary>
        /// 移除错误信息
        /// </summary>
        /// <param name="error">验证错误信息</param>
        /// <returns></returns>
		public ValidationResult Remove(ValidationError error)
		{
			if (_errors.Contains(error))
				_errors.Remove(error);
			return this;
		}
	}
}
