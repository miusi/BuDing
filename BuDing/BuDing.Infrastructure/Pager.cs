using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure
{
	public class Pager
	{
		/// <summary>
		/// 总行数
		/// </summary>
		public int totalRows { set; get; }

		/// <summary>
		/// 每页显示的行数
		/// </summary>
		public int pageSize { set; get; }

		/// <summary>
		/// 当前页号
		/// </summary>
		public int pageNo { set; get; }

		/// <summary>
		/// 总页数
		/// </summary>
		public int totalPages { set; get; }

		public string _direction = "asc";
		/// <summary>
		/// 排序方向
		/// </summary>
		public string direction
		{
			get
			{
				return _direction;
			}
			set
			{
				_direction = value = string.Equals("asc", value, StringComparison.OrdinalIgnoreCase) ? "asc" : "desc";
			}
		}

		/// <summary>
		/// 排序字段
		/// </summary>
		public string sort { set; get; }

		/// <summary>
		/// 数据内容
		/// </summary>
		public object rows { set; get; }
		/// <summary>
		/// 默认显示
		/// </summary>
		public Pager()
		{
			totalRows = 0;
			pageSize = 20;
			pageNo = 1;
			totalPages = 0;
		}
	}
}
