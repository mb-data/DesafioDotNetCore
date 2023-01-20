using APIDesafioDotNetCore.BancoDeDados.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIDesafioDotNetCore.BancoDeDados.Mappings
{
    internal sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(_ => _.Id);

            builder.Property(_ => _.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(_ => _.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Price).HasColumnName("Price").IsRequired();
            builder.Property(_ => _.Brand).HasColumnName("Brand").IsRequired().HasMaxLength(255);
            builder.Property(_ => _.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();
            builder.Property(_ => _.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}
