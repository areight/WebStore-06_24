using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt =>
            {
                //opt.Filters.Add<Filter>();
                //opt.Conventions.Add(); // ����������/��������� ���������� MVC-����������
            }).AddRazorRuntimeCompilation();

            services.AddScoped<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, InMemoryProductData>();

            //services.AddTransient<TInterface, TService>();
            //services.AddScoped<TInterface, TService>();
            //services.AddSingleton<TInterface, TService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            //var employees1 = services.GetRequiredService<IEmployeesData>();
            //var employees2 = services.GetRequiredService<IEmployeesData>();

            //var hash1 = employees1.GetHashCode();
            //var hash2 = employees2.GetHashCode();

            //using (var scope = services.CreateScope())
            //{
            //    var employees3 = scope.ServiceProvider.GetRequiredService<IEmployeesData>();
            //    var employees4 = scope.ServiceProvider.GetRequiredService<IEmployeesData>();
            //    var hash3 = employees3.GetHashCode();
            //    var hash4 = employees3.GetHashCode();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseWelcomePage("/welcome");

            //app.Use(async (context, next) =>
            //{
            //    //�������� ��� context �� ���������� �������� � ���������
            //    await next(); // ����� ���������� �������������� �� � ���������
            //    // �������� ��� context ����� ���������� �������� � ���������
            //});

            //app.UseMiddleware<TestMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync(_Configuration["CustomGreetings"]);
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
