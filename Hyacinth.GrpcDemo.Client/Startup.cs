using Hyacinth.GrpcDemo.Framework;
using Hyacinth.GrpcDemo.LessonServer;
using Hyacinth.GrpcDemo.UserServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hyacinth.GrpcDemo.Client
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
            services.AddControllersWithViews();
            services.AddTransient<CustomClientLoggerInterceptor>();

            services.AddGrpcClient<User.UserClient>(options =>
            {
                options.Address = new Uri("http://hyacinth.grpcdemo.userserver:80");
            }).AddInterceptor<CustomClientLoggerInterceptor>();
            services.AddGrpcClient<Lesson.LessonClient>(options =>
            {
                options.Address = new Uri("http://hyacinth.grpcdemo.lessonserver:80");
            }).AddInterceptor<CustomClientLoggerInterceptor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
