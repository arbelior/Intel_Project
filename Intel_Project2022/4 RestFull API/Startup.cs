using intelpro;
using IntelPro;
using IntelPro.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class Startup
    {
        private readonly string _my_key = "My Very Long Key To Sign";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(setup => setup.AddPolicy("EntireAllWorld", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddCors(setup => setup.AddPolicy("LocalhostDev", policy => policy.WithOrigins("http://localhost:57681").AllowAnyMethod().AllowAnyHeader()));
            services.AddSingleton<UserLogic>();
            services.AddSingleton<DataLogic>();
            services.AddSingleton<IJwtHelper>( new JwtHelper(_my_key));
            services.AddSingleton<FilesLogic>();

            services.AddControllersWithViews();
                

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
              
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_my_key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });;

            //jwthelper jwtHelper = new jwthelper(Configuration.GetValue<string>("JWT:Key"));
            //services.AddSingleton(jwtHelper);

            //services.AddAuthentication(options => jwtHelper.setauthenticationoptions(options))
            //    .AddJwtBearer(options => jwtHelper.setbeareroptions(options));

            services.AddControllersWithViews();
            services.AddSingleton<DataLogic>();
            services.AddSingleton<UserLogic>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "_4_RestFull_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "_4_RestFull_API v1");
                    //c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("EntireAllWorld");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
