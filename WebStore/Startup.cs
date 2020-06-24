using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebStore
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;
        public Startup (IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                                    // Handles exceptions (for developers),
                app.UseDeveloperExceptionPage(); // increases safety & hides file structure
            }                                    // by not showing the error message                      (?)

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting(); // Routing

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context => await context.Response.WriteAsync(_Configuration["CustomGreetings"]));

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Response");
                });

                endpoints.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=Index}/{id?}");
            });
            // Handles endpoints.
            // An endpoint is the parts after a slash (except the first one?)
        }
    }
}
