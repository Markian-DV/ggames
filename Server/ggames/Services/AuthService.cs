﻿using ggames.Data;
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
        private readonly AppDataContext _appDataContext;
        private readonly IFBAuthService _facebookAuthService;
        public AuthService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, AppDataContext appDataContext, IFBAuthService facebookAuthService = null)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _appDataContext = appDataContext;
            _facebookAuthService = facebookAuthService;
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

            // add info in ChessRating table 
            await _appDataContext.ChessRatings.AddAsync(new ChessRating
            {
                Rating = 0,
                UserId = (await _userManager.GetUserIdAsync(newUser)).ToString()
            });
            await _appDataContext.SaveChangesAsync();

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
                    new Claim("userName",User.UserName),
                    new Claim("id", User.Id)
                };

            var userRoles = await _userManager.GetRolesAsync(User);
            if (userRoles.Count > 0)
            {
                foreach (var role in userRoles)
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

        public async Task<AuthResult> LoginWithFacebookAsync(string accessToken)
        {
            var validateTokenResult = await _facebookAuthService.ValidateAccessTokenAsync(accessToken);

            if (!validateTokenResult.Data.IsValid)
            {
                return new AuthResult
                {
                    Errors = new[] { "invalid facebook token" }
                };

            }

            var userInfo = await _facebookAuthService.GetUserInfoAsync(accessToken);

            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            if (user == null)
            {
                IdentityUser identityUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = userInfo.Email,
                    UserName = userInfo.Email.Split("@")[0]
                };
                var created = await _userManager.CreateAsync(identityUser);
                if (!created.Succeeded)
                {
                    return new AuthResult
                    {
                        Errors = new[] { "smth went wrong " }
                    };
                }

                // add info in ChessRating table
                await _appDataContext.ChessRatings.AddAsync(new ChessRating
                {
                    Rating = 0,
                    UserId = (await _userManager.GetUserIdAsync(identityUser)).ToString()
                });
                await _appDataContext.SaveChangesAsync();

                await _userManager.AddToRoleAsync(identityUser, "User");

                return await GenerateAuthenticationResultForUserAsync(identityUser);

            }
            else
            {
                return await GenerateAuthenticationResultForUserAsync(user);
            }


        }
    }
}
