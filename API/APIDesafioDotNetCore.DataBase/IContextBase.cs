using APIDesafioDotNetCore.BancoDeDados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioDotNetCore.DataBase
{
    /// <summary>
    /// Database context definition
    /// </summary>
    public interface IContextBase
    {
        /// <summary>
        /// Products entity
        /// </summary>
        DbSet<Product> Products { get; }

        /// <summary>
        /// Push all changes to database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to notify the execution cancellation</param>
        /// <returns>Task to async push execution</returns>
        Task<int> Push(CancellationToken cancellationToken);
    }
}
