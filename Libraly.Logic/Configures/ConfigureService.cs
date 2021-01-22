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

namespace Libraly.Logic.Configures
{
    public static class  ConfigureService
    {
        public static IServiceCollection InitServices(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("Default")));


            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAutoMapper(typeof(ConfigurationOfMapping));

            return services;
        }
    }
}
