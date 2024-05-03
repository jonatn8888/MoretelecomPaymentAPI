//Payment API with Policy Admin or User
//Username = "test1", Password = "password1", Role = "User"
//Username = "test2", Password = "password2", Role = "Administrator"
//TokenKey is located in appsettings json


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MoretelecomPaymentAPI.Main;

namespace MoretelecomPaymentAPI.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
