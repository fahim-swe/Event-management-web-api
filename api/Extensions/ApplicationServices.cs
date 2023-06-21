using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using repository.Database.Generic;
using repository.Database.UnitOfWork;
using repository.Interfaces;
using repository.StoreContext;
using jwtAuth.Model;
using jwtAuth.Interfaces;
using jwtAuth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using api.Helper;
using Microsoft.Extensions.Logging;

namespace api.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection DatabaseServices(this IServiceCollection services, IConfiguration _config)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>( 
                dbContextOptions => dbContextOptions
                    .UseMySql(
                    connectionString,  
                    ServerVersion.AutoDetect(connectionString), 
                    b => b.MigrationsAssembly("api")
            ));

            services.AddScoped<IUnitOkWork, UnitOfWork>();
            
            return services;
        }


        public static IServiceCollection IdentityServices(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<TokenSetting>(_config.GetSection("JWT"));
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(
                            options => {
                                options.SaveToken = true;
                                options.RequireHttpsMetadata = false;
                                options.TokenValidationParameters = new TokenValidationParameters()
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = false,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ClockSkew = TimeSpan.Zero,
                                    
                                    ValidAudience = _config["JWT:ValidAudience"],
                                    ValidIssuer = _config["JWT:ValidIssuer"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]))
                                };
                            }                        
                        );

            return services;
        }


        public static IServiceCollection OtherApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddHttpContextAccessor();


          

            return services;
        }   
    }
}