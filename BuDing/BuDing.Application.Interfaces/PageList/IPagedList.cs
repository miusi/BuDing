using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Application.Interfaces.PageList
{
    public interface IPagedList<T>
    {
        /// <summary>
        /// 页码起始
        /// </summary>
        int IndexFrom { get; }

        /// <summary>
        /// 当前页
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// 页码
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// 总记录数
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// 当前页的记录
        /// </summary>
        IList<T> Items { get; }

        /// <summary>
        /// 是否有前一页
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有后一页
        /// </summary>
        bool HasNextPage { get; }
    }
}
