using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.Logic.Initializers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Libraly.Logic.Models.UserDTO;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Services;

namespace Libraly_test2_
{
    public class Program
    {
        
        public static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userService = services.GetRequiredService<IUserService>();
                    await RoleInit.InitAsync(userService);
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Проблема с добавление в бд");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
