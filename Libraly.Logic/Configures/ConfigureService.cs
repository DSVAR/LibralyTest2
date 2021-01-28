using Libraly.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Identity.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Entities;
using AutoMapper;
using Libraly.Logic.Services;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.UserDTO;

namespace Libraly.Logic.Configures
{
    public static class  ConfigureService
    {
        public static IServiceCollection InitServices(IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAutoMapper(typeof(ConfigurationOfMapping));

            services.AddTransient(typeof(IUserService), typeof(UserService));

            return services;
        }
    }
}
