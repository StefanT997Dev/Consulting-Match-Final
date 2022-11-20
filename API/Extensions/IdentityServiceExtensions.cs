using System.Text;
using System.Threading.Tasks;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>();

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt=>
                {
                    opt.TokenValidationParameters=new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer=false,
                        ValidateAudience=false
                    };
                    opt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived= context =>
                        {
                            var accessToken = context.Request.Headers["access_token"];
                            var path=context.HttpContext.Request.Path;
                            if(!string.IsNullOrEmpty(accessToken))
                            {
                                context.Token=accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<TokenService>();

            return services;
        }
    }
}