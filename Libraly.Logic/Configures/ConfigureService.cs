﻿using Libraly.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Libraly.Data.Entities;
using AutoMapper;
using Libraly.Logic.Services;
using Libraly.Logic.Interfaces;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;

namespace Libraly.Logic.Configures
{
    public static class  ConfigureService
    {
        public static IServiceCollection InitServices(IServiceCollection services,IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b=>b.MigrationsAssembly("Libraly.Data")
                ));

            
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAutoMapper(typeof(ConfigurationOfMapping));
           

            services.AddTransient(typeof(IUserService), typeof(UserService));
           
            services.AddScoped(typeof(IBookService),typeof(BookService));
            services.AddTransient(typeof(IBasedata<>), typeof(BasedataRepository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWorkRepository));

            return services;
        }
    }
}
