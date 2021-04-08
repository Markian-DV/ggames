using ggames.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ggames
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var serviceScope = host.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDataContext>();

                await dbContext.Database.MigrateAsync();


                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(! await roleManager.RoleExistsAsync("Admin"))
                {
                    var AdminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(AdminRole);
                }
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    var UserRole = new IdentityRole("User");
                    await roleManager.CreateAsync(UserRole);
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                if(await userManager.FindByEmailAsync("admin@test.com")==null)
                {
                    var newUser = new IdentityUser
                    {
                        Id = "0aea6483-9e45-4993-874d-4de5b3a58276",
                        Email = "admin@test.com",
                        UserName = "admin",                    
                    };

                    //0aea6483-9e45-4993-874d-4de5b3a58276
                    await userManager.CreateAsync(newUser, "123Hello_World!!!");
                    await userManager.AddToRoleAsync(newUser, "admin");
                }

            }


            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
