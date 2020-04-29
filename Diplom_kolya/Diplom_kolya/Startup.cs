using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diplom.Data;
using Diplom_kolya.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Diplom_kolya
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContexts(Configuration);
            services.AddServices();
            services.AddControllers();
            services.AddCors();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder=>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            });

            app.Use((context, next) =>
            {
                
                context.Request.Headers["Allow"] = "GET,POST,PUT,DELETE,OPTIONS";
                //context.Request.Headers["Access-Control-Allow-Origin"] = "GET,POST,PUT,DELETE,OPTIONS";
                context.Request.ContentType = "application/json";
                context.Response.ContentType = "application/json";

                return next.Invoke();
            });

            app.UseHttpsRedirection();

            app.UseRouting();
      
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}