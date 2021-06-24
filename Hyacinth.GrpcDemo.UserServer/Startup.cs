using Hyacinth.GrpcDemo.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hyacinth.GrpcDemo.UserServer
{
    public class Startup
    {
        // 此方法由运行时调用。 使用此方法向容器添加服务。
        // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.Interceptors.Add(typeof(CustomServerLoggerInterceptor));
            });
        }

        // 此方法由运行时调用。 使用此方法配置 HTTP 请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<UserService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("与 gRPC 端点的通信必须通过 gRPC 客户端进行。 要了解如何创建客户端，请访问：https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
