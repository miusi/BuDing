//-----------------------------------------------------------------------
// <copyright file="ValidationError.cs">
// * Copyright (C) 2018 Godric All Rights Reserved
// * version : 4.0.30319.42000 
// * FileName: ValidationError.cs 
// </copyright>
//-----------------------------------------------------------------------

namespace BuDing.Infrastructure.ValidationLogic
{
    /// <summary>
    /// ValidationError
    /// 异常结果
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
    public class ValidationError
	{
        /// <summary>
        /// 信息
        /// </summary>
		public string Message { get; set; }

        /// <summary>
        /// cotr
        /// </summary>
        /// <param name="message"></param>
		public ValidationError(string message)
		{
			Message = message;
		}
	}
}
