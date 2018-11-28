using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuDing.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		[HttpGet("login")]
		[HttpPost("login")]
		public ActionResult Login(string username,string password)
		{
			return new JsonResult(new { data = new { token = "1111111" } });
		}
    }
}