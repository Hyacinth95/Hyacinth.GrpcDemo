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

        // ��Ҫ��������ò����� macOS �ϳɹ����� gRPC��
        // �й������ macOS ������ Kestrel �� gRPC �ͻ��˵�˵��������� https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
