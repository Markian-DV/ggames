using ggames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute]Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {

            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null) { return NotFound(); }
            var deleted = await _userManager.DeleteAsync(user);
            if (deleted.Succeeded) return NoContent();
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] UpdateToAdminModel updateToAdmimModel)
        {
            var user = await _userManager.FindByEmailAsync(updateToAdmimModel.Email);

            if (user == null) return NotFound();

            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok(user);
        }

    }
}
