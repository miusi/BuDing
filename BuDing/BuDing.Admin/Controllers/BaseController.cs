 
using Microsoft.AspNetCore.Cors; 
using Microsoft.AspNetCore.Mvc;

namespace BuDing.Admin.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors("AllowAllOrigin")]
	public class BaseController : ControllerBase
    {
    }
}