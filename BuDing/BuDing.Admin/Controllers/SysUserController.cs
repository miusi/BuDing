using System;
using System.Collections.Generic;
using BuDing.Application.Interfaces.PageList;
using BuDing.Application.Interfaces.Services;
using BuDing.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuDing.Admin.Controllers
{ 
    public class SysUserController : BaseControllerController
    {
        private ISysUserService _sysUserDataService;

        public SysUserController(ISysUserService sysUserDataService)
        {
            this._sysUserDataService = sysUserDataService;
        }



		// GET: api/SysUser
		[HttpGet]
		public IPagedList<SysUserEntity> Get()
		{
			return _sysUserDataService.GetPagedList(0, 20);
		}

		// GET: api/SysUser/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			return Ok(_sysUserDataService.Get(id));
		}

		// POST: api/SysUser
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT: api/SysUser/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}