using APIDesafioDotNetCore.BancoDeDados;
using APIDesafioDotNetCore.DataBase;
using APIDesafioDotNetCore.DataBase.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace APIDesafioDotNetCore
{
    public class Startup
    {
        private readonly IConfiguration _configuracoes;
        private readonly IWebHostEnvironment _ambiente;

        public Startup(IConfiguration configuracoes, IWebHostEnvironment ambiente)
        {
            _configuracoes = configuracoes;
            _ambiente = ambiente;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHealthChecks()
                    .AddSqlServer(_configuracoes["ConnectionStrings_SqlServerConnection"], name: "Banco de Dados");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Serviço de Produtos",
                    Description = "Especificação da API de serviços de produtos"
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            });

            services.AddControllers()
                    .AddJsonOptions(
                        option =>
                        {
                            option
                            .JsonSerializerOptions
                            .ReferenceHandler =
                                ReferenceHandler.Preserve;
                        }
                    );

            services.AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<IContextBase, Context>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_ambiente.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger().UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Serviço de Produtos"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
                option => option.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
