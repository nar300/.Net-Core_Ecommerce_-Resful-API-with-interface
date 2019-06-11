using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,

           ValidIssuer = "http://localhost:5000",
           ValidAudience = "http://localhost:5000",
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
       };
   });
            services.AddScoped<IAuthRepository, AuthRepositoryImpl>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(Options => {
                    var resolver = Options.SerializerSettings.ContractResolver;
                    if (resolver != null) (resolver as DefaultContractResolver).NamingStrategy = null;
                });
            services.AddDbContext<EcomDbContext>(option=>option.UseSqlServer(Configuration.GetConnectionString("dbconnection")));
            services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
            services.AddScoped<IProductRepository, ProductImpl>();
            services.AddCors();
            services.AddScoped<IUserRepository,UserRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors(Options => Options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
