using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.Attributes
{ 
    public sealed class StatusCodeAttribute:Attribute
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code;

        /// <summary>
        /// 状态描述
        /// </summary>
        public string Description;

        /// <summary>
        /// cotr
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="description">状态描述</param>
        public StatusCodeAttribute(int code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}
