using ggames.Data;
using ggames.Helpers;
using ggames.Models;
using ggames.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{
 
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }


        [Route(ApiRoutes.Auth.Register)]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (registerModel == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(new 
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _authService.RegisterAsync(registerModel.Email, registerModel.Password, registerModel.UserName);
            if (!authResponse.Success)
            {
                return BadRequest(new 
                {
                    Errors = authResponse.Errors
                });
            }
            
            return Ok(new 
            {
                Token = authResponse.Token
            });

        }

        [Route(ApiRoutes.Auth.Login)]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _authService.LoginAsync(loginModel.Email, loginModel.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new 
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new 
            {
                Token = authResponse.Token
            });
        }


        [Route(ApiRoutes.Auth.FBAuth)]
        [HttpPost]
        public async Task<IActionResult> FBLogin([FromBody] UserFBAuthRequest request)
        {
            var authResponse = await _authService.LoginWithFacebookAsync(request.accessToken);
            if (!authResponse.Success)
            {
                return BadRequest(new 
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new 
            {
                Token = authResponse.Token
            });

        }
    }
}
