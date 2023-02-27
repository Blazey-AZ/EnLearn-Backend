using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.Helpers;
using enlearn.Interfaces;
using enlearn.Services;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            }));


            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            return services;

            

        }
    }
}