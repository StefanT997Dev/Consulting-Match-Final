using API.Extensions;
using API.Extensions.RepositoryServices;
using API.Middleware;
using API.SignalR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Application.Categories.Create;
using static Application.Reviews.Exists;

namespace API
{
	public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(opt =>
            {
                var policy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<CommandValidator>();
            });

            services.AddApplicationServices(_config);

            services.AddIdentityServices(_config);

            services.AddRepositoryServices();

            services.AddCors(opt=>
            {
                opt.AddPolicy("CorsPolicy",policy=>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(
                        "http://localhost:3000", 
                        "https://it-mentor-ui.herokuapp.com", 
                        "http://it-mentor-ui.herokuapp.com",
                        "https://keen-almeida-bff700.netlify.app");
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<MessageHub>("/message");*/
            });
        }
    }
}
