using ggames.Models;
using ggames.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ggames.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }





        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthResult
                {
                    Errors = new[] { "User does not exist" },
                    Success = false
                };

            }

            bool IsPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!IsPasswordValid)
            {
                return new AuthResult
                {
                    Errors = new[] { "Password is wrong" },
                    Success = false
                };
            }

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthResult> RegisterAsync(string email, string password, string username)
        {
            var UserExists = await _userManager.FindByEmailAsync(email);
            if (UserExists != null)
            {
                return new AuthResult
                {
                    Errors = new[] { "User with this email address already exists" },
                    Success = false

                };

            }
            var newUser = new IdentityUser
            {
                Email = email,
                UserName = username

            };
            
            var createdUser = await _userManager.CreateAsync(newUser, password);

           

            if (!createdUser.Succeeded)
            {
                return new AuthResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description),
                    Success = false
                };
            }

            await _userManager.AddToRoleAsync(newUser, "User");

            return await GenerateAuthenticationResultForUserAsync(newUser);
        }




        private async Task<AuthResult> GenerateAuthenticationResultForUserAsync(IdentityUser User)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub,User.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,User.Email),
                    new Claim("UserName",User.UserName),
                    new Claim("id", User.Id)
                };

            var userRoles = await _userManager.GetRolesAsync(User);
            if(userRoles.Count>0)
            {
                foreach(var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);



            return new AuthResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
