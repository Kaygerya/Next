using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyNextMatch.Core.Settings;
using MyNextMatch.DataAccess.Abstract;
using MyNextMatch.DataAccess.Services;
using MyNextMatch.Service.Abstract;
using MyNextMatch.Service.Services;

namespace MyNextMatch.UserAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration.GetSection("ManagerSettings").Get<ManagerSettings>());
            services.AddDbContext<MyNextMatchDatabaseContext>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDAL, EfUserDAL>();

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "My Next Match   - Catalog HTTP API",
                    Version = "v1",
                    Description = "The User Microservice HTTP API. This is a Data-Driven/CRUD microservice sample",
                    TermsOfService = "Terms Of Service"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger()
      .UseSwaggerUI(c =>
      {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });
        }
    }
}
