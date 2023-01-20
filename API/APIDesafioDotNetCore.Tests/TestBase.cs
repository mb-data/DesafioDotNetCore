using APIDesafioDotNetCore.DataBase;
using APIDesafioDotNetCore.Tests.TestContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIDesafioDotNetCore.Tests
{
    internal abstract class TestBase : IDisposable
    {
        private bool _recursoLiberado;

        protected TestBase()
        {
            Server = new WebApplicationFactory<Program>()
                    .WithWebHostBuilder(builder =>
                    {
                        builder.UseEnvironment("Test");

                        builder.ConfigureAppConfiguration((context, builder) =>
                        {
                            builder.AddEnvironmentVariables();
                        });

                        builder.ConfigureServices((context, services) =>
                        {
                            services.AddScoped<IContextBase, ContextTest>();
                        });
                    });
        }

        public WebApplicationFactory<Program> Server { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool liberarRecursosGerenciados)
        {
            if (!_recursoLiberado)
            {
                _recursoLiberado = true;

                if (liberarRecursosGerenciados)
                {
                    Server.Dispose();
                }
            }
        }
    }
}
