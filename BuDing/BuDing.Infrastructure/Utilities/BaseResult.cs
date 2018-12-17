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
		/// 返回消息内容
		/// </summary>
		public string StatusMessage = "未知错误";
				
		public ValidationResult ValidationResult { get; set; }

		/// <summary>
		/// 查询分页数据时返回记录条数用
		/// </summary>
		public int RecordCount = 0;
	}
}
