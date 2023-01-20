using System.Security.Authentication;

namespace APIDesafioDotNetCore
{
    public class Program
    {
        protected Program() {}

        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((x, y) =>
                {
                    y.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{x.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
                }
                        );

                webBuilder.ConfigureKestrel(x =>
                {
                    x.AddServerHeader = false;
                    x.ConfigureHttpsDefaults(y => y.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13);
                }
                        );

                webBuilder.UseSetting(WebHostDefaults.ApplicationKey, "API Desafio Dot Net Core")
                                  .CaptureStartupErrors(true)
                                  .UseStartup<Startup>();
            }
            );
    }
}