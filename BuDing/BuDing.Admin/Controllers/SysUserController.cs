using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuDing.Application.Interfaces.PageList;
using BuDing.Application.Interfaces.Services;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.Utilities;
using BuDing.Infrastructure.ValidationLogic;
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
		public IActionResult Get()
		{
			JsonResult<IPagedList<SysUserEntity>> result = new JsonResult<IPagedList<SysUserEntity>>();
			result.Status = true;
			result.StatusCode = "200";
			result.Data = sysUserService.Find().ToPagedList<SysUserEntity>(0, 20);
			return Ok(result);
		}


		/// <summary>
		/// 通过Id获取系统用户实体
		/// </summary>
		/// <param name="id">id</param>
		/// <returns></returns>
		// GET: api/SysUser/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			JsonResult<SysUserEntity> result = new JsonResult<SysUserEntity>();
			result.Status = true;
			result.StatusCode = "200";
			result.Data = sysUserService.Get(id);
			return Ok(result);
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="entity">系统用户</param>
		// POST: api/SysUser
		[HttpPost]
		public IActionResult Post([FromBody] SysUserEntity entity)
		{
			JsonResult<ValidationResult> jsonResult = new JsonResult<ValidationResult>();
			if (entity != null)
			{
				var validationResult = sysUserService.Add(entity);
				jsonResult.Data = validationResult;
			}
			else
			{
				ValidationResult validationResult = new ValidationResult();
				validationResult.Add("新增数据不能为空");
				jsonResult.Data = validationResult;
			}
			return Ok(jsonResult);
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

		/// <summary>
		/// 登陆
		/// </summary>
		/// <param name="username">用户名</param>
		/// <param name="password">密码</param>
		/// <returns></returns>
		[HttpPost]
		[Route("api/SysUser/Login")]
		public IActionResult Login(string username, string password)
		{
			return Ok(sysUserService.Login(username, password));
		}
	}
}
