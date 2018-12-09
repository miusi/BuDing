using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuDing.Application.Interfaces.BusinessLogic;
using BuDing.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuDing.Admin.Controllers
{ 
    public class SysUserController : BaseControllerController
    {
        private ISysUserDataService _sysUserDataService;

        public SysUserController(ISysUserDataService sysUserDataService)
        {
            this.sysUserDataService = sysUserDataService;
        }



        // GET: api/SysRole
        [HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/SysRole/5
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			return Ok(sysUserBusinessLogic.GetSysUserById(id));
		}

		// POST: api/SysRole
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT: api/SysRole/5
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