using Libraly.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Logic.Configures
{
    public static class  ConfigureService
    {
        public static IServiceCollection InitServices(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("Default")));
            return services;
        }
    }
}
