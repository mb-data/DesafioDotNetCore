using APIDesafioDotNetCore.BancoDeDados;
using APIDesafioDotNetCore.BancoDeDados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace APIDesafioDotNetCore.DataBase.Repositories
{
    /// <summary>
    /// Product repository implementation
    /// </summary>
    public sealed class ProductRepository : IProductRepository
    {
        private IContextBase _context;

        /// <summary>
        /// Init a <see cref="ProductRepository"/> object
        /// </summary>
        /// <param name="context">Database context</param>
        public ProductRepository(IContextBase context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Product> GetProductById(int id, CancellationToken cancellationToken)
            => _context.Products.Local.FirstOrDefault(_ => _.Id.Equals(_)) ??
            await _context.Products.AsQueryable().FirstOrDefaultAsync(_ => _.Id.Equals(id), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public async Task<Product> GetLastProduct(CancellationToken cancellationToken)
            => _context.Products.Local.OrderBy(_=>_.Id).LastOrDefault() ??
            await _context.Products.AsQueryable().OrderBy(_ => _.Id).LastOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public IEnumerable<Product> GetAllProduct()
            => _context.Products;

        /// <inheritdoc />
        public void Add(Product product)
            => _context.Products.Add(product);

        /// <inheritdoc />
        public void Add(IEnumerable<Product> products)
            => _context.Products.AddRange(products.Cast<Product>());

        /// <inheritdoc />
        public void Update(Product product)
            => _context.Products.Update(product);

        /// <inheritdoc />
        public void Exclude(Product product)
            => _context.Products.Remove(product);

        /// <inheritdoc />
        public void Exclude(IEnumerable<Product> entidades)
            => _context.Products.RemoveRange(entidades.Cast<Product>());

        /// <inheritdoc />
        public async Task Push(CancellationToken cancellationToken)
            => await _context.Push(cancellationToken).ConfigureAwait(false);

        }
}
