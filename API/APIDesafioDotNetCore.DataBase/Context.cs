using APIDesafioDotNetCore.BancoDeDados.Entidades;
using APIDesafioDotNetCore.BancoDeDados.Entities;
using APIDesafioDotNetCore.BancoDeDados.Mappings;
using APIDesafioDotNetCore.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APIDesafioDotNetCore.BancoDeDados
{
    /// <summary>
    /// Data base context implementation
    /// </summary>
    public sealed class Context : ContextBase
    {

        /// <summary>
        /// Init a <see cref="Context"/> object
        /// </summary>
        /// <param name="configuration">Configuration file object</param>
        public Context(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString).UseLazyLoadingProxies();

    }
}