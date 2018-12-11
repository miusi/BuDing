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
	[Route("api/[controller]")]
	[ApiController]
	public class SysUserController : BaseController
	{
		private ISysUserService sysUserService;

		public SysUserController(ISysUserService sysUserService)
		{
			this.sysUserService = sysUserService;
		}

		// GET: api/SysUser
		[HttpGet]
		public IEnumerable<SysUserEntity> Get()
		{
			return sysUserService.Find(null);
		}

		//[HttpGet("{username}", Name = "Get")]
		//public IEnumerable<SysUserEntity> Get(string username)
		//{
		//	return sysUserService.Find(t => t.Name == username);
		//}

		// GET: api/SysUser/5
		[HttpGet("{id}", Name = "Get")]
		public SysUserEntity Get(int id)
		{
			return sysUserService.Get(id);
		}

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
