using CloudinaryDotNet;
using DatingAPP.helpers;
using Domain.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Services.Services;
using Services.UnitOfWork;
using System.Text;

namespace DatingAPP.Extinsion
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IPhotoServices, PhotoServices>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<mkContext>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddCors(P => P.AddPolicy("crospolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));



            return services;
        }
    }
}
