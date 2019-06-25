using coreapi.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace coreapi
{
    public class Startup
    {
		 private readonly string API_GUID = string.Empty;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
			 API_GUID = Guid.NewGuid().ToString();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.Use(async (context, next) =>
            //{
            //    //var cultureQuery = context.Request.Query["culture"];
            //    //if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    //{
            //    //    var culture = new CultureInfo(cultureQuery);

            //    //    CultureInfo.CurrentCulture = culture;
            //    //    CultureInfo.CurrentUICulture = culture;
            //    //}                
            //    //context.Response.WriteAsync($"Hello world ");

            //    // Call the next delegate/middleware in the pipeline
            //    await next();

            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(
            //        $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            //});

            //app.Use 
			  app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("x-process-identifier", API_GUID);
                await next.Invoke();               
            });

            app.UseCustomHeader();
            app.UseHttpsRedirection();            
            app.UseMvc();
        }
    }
}
