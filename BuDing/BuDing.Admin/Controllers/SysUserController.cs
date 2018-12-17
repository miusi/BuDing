using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuDing.Application.Interfaces.Services;
using BuDing.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuDing.Admin.Controllers
{

	/// <summary> 
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SysUserController : BaseController
	{
		private ISysUserService sysUserService;

		private IHttpContextAccessor _accessor;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="sysUserService">系统用户服务对象</param> 
		public SysUserController(ISysUserService sysUserService)
		{
			this.sysUserService = sysUserService; 

		}

		/// <summary>
		/// 获取对象
		/// </summary>
		/// <returns></returns>
		// GET: api/SysUser
		[HttpGet]
		public IEnumerable<SysUserEntity> Get()
		{ 
			return sysUserService.Find(null);
		}

	 

		// GET: api/SysUser/5
		[HttpGet("{id}", Name = "Get")]
		public SysUserEntity Get(int id)
		{
			return sysUserService.Get(id);
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity">系统</param>
		// POST: api/SysUser
		[HttpPost]
		public void Post([FromBody] SysUserEntity entity)
		{
		}

		// PUT: api/SysUser/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] SysUserEntity entity)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			sysUserService.Delete(id);
		}
	}
}
