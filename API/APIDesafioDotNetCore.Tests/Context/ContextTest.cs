using APIDesafioDotNetCore.BancoDeDados.Entidades;
using APIDesafioDotNetCore.DataBase;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDesafioDotNetCore.Tests.TestContext
{
    internal sealed class ContextTest : ContextBase
    {
        public ContextTest()
            : base("Filename=:memory:")
        {
            Database.EnsureCreated();
        }

        protected sealed override Action<ModelBuilder> DataInitialize => modelBuilder =>
        {
            ProductCreation(modelBuilder);
        };

        protected sealed override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = new SqliteConnection(ConnectionString);
            conexao.Open();

            optionsBuilder.UseSqlite(conexao)
                          .UseLazyLoadingProxies()
                          .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        private static void ProductCreation(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Product>(builder =>
            {
                _ = builder.HasData(
                        new
                        {
                            Name = "Car",
                            Price = (decimal)2500.00,
                            Brand = "Ferrari",
                            Id = 1,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        },

                        new
                        {
                            Name = "BasketBall",
                            Price = (decimal)100.00,
                            Brand = "Jordan",
                            Id = 2,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        }
                    );
            });
        }
    }
}
