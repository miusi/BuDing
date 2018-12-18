using BuDing.Infrastructure.ValidationLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.Utilities
{
	public class BaseResult
	{
		/// <summary>
		/// 操作是否成功 
		/// </summary>
		public bool Status = false;

		/// <summary>
		/// 返回值
		/// </summary>
		public string ResultValue = "";

		/// <summary>
		/// 返回状态代码
		/// </summary>
		public string StatusCode = "UnknownError";

		/// <summary>
		/// 验证结果
		/// </summary>
		public ValidationResult ValidationResult { get; set; }
		
		/// <summary>
		/// cotr
		/// </summary>
		public BaseResult()
		{
			this.Status = false;
			this.ValidationResult = new ValidationResult();
		}

		/// <summary>
		/// 输出成功消息
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static BaseResult Success()
		{
			return new BaseResult()
			{
				Status = true
			};
		}

		/// <summary>
		/// 输出失败消息
		/// </summary>
		/// <returns></returns>
		public static BaseResult Fail()
		{
			return new BaseResult()
			{
				Status = false
			};
		}

		/// <summary>
		/// 输入错误信息
		/// </summary>
		/// <returns></returns>
		public static BaseResult Error()
		{
			return new BaseResult()
			{
				Status = false
			};
		}
	}

	/// <summary>
	/// json
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonResult<T> : BaseResult
	{
		public T Data { get; set; }
	}
}
