using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{
    [Authorize]
    [Route("test/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("Index/")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("hello my little world");
        }
    }
}
