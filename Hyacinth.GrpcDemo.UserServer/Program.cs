using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Hyacinth.GrpcDemo.UserServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // 需要额外的配置才能在 macOS 上成功运行 gRPC。
        // 有关如何在 macOS 上配置 Kestrel 和 gRPC 客户端的说明，请访问 https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
