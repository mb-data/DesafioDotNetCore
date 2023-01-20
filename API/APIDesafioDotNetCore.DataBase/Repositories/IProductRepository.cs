using APIDesafioDotNetCore.BancoDeDados.Entidades;

namespace APIDesafioDotNetCore.DataBase.Repositories
{
    /// <summary>
    /// Product repository definition
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id">Product ID to get</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<Product> GetProductById(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Get last product add.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<Product> GetLastProduct(CancellationToken cancellationToken);

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        IEnumerable<Product> GetAllProduct();

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="product">Product to add</param>
        void Add(Product product);

        /// <summary>
        /// Add product collection
        /// </summary>
        /// <param name="products">Products to add</param>
        void Add(IEnumerable<Product> products);

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Product to update</param>
        void Update(Product product);

        /// <summary>
        /// Exclude product
        /// </summary>
        /// <param name="product">Product to exclude</param>
        void Exclude(Product product);

        /// <summary>
        /// Exclude product collection
        /// </summary>
        /// <param name="entidades">Products to exclude</param>
        void Exclude(IEnumerable<Product> entidades);

        /// <summary>
        /// Push all changes to database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to notify the execution cancellation</param>
        /// <returns>Task to async push execution</returns>
        Task Push(CancellationToken cancellationToken);

    }
}
