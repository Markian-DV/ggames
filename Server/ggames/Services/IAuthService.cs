using ggames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(string email, string password, string username);

        Task<AuthResult> LoginAsync(string email, string password);

        Task<AuthResult> LoginWithFacebookAsync(string accessToken);
    }
}
