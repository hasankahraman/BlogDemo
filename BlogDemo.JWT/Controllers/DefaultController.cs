using BlogDemo.JWT.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Homepage()
        {
            return Ok("Successfully logined to homepage");
        }
    }
}
