using ggames.Helpers;
using ggames.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route(ApiRoutes.Auth.Register)]
        [HttpGet]
        public async Task<IActionResult> Create(ArticleModel registerModel)
        {
            var articles;

            return Ok(new
            {
                Token = authResponse.Token
            });

        }
    }
}
