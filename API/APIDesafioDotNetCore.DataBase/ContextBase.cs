using APIDesafioDotNetCore.BancoDeDados.Entidades;
using APIDesafioDotNetCore.BancoDeDados.Entities;
using APIDesafioDotNetCore.BancoDeDados.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDesafioDotNetCore.DataBase
{
    public abstract class ContextBase : DbContext, IContextBase
    {
        public DbSet<Product> Products { get; set; }

        public string ConnectionString { get; }

        protected virtual Action<ModelBuilder> DataInitialize { get; }

        public ContextBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public ContextBase(IConfiguration configuration)
            : this(configuration["ConnectionString"])
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new ProductMapping()); 
            DataInitialize?.Invoke(modelBuilder);
        }

        /// <inheritdoc />
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AddTimestamps();

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<int> Push(CancellationToken cancellationToken)
            => await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                var now = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((EntityBase)entity.Entity).CreatedAt = now;
                }
                ((EntityBase)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
