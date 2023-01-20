using APIDesafioDotNetCore.BancoDeDados.Entidades;
using APIDesafioDotNetCore.DataBase.Repositories;
using APIDesafioDotNetCore.OT.ChangeProductEntity.Request;
using APIDesafioDotNetCore.OT.ChangeProductEntity.Response;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioDotNetCore.Controllers
{
    [ApiController, Route("api/v1/products")]
    [Consumes("application/json"), Produces("application/json")]
    public class ProductController : ControllerBase
    {
        IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <remarks>
        /// Exemple request:
        ///
        ///     GET /api/v1/products
        ///     
        /// </remarks>
        /// <returns>Collection of products</returns>
        /// <response code="200">Return products.</response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ChangeProductEntityResponse> GetAllProducts()
        {
            List<ChangeProductEntityResponse> response = new List<ChangeProductEntityResponse>();
            var products = _productRepository.GetAllProduct();

            foreach (var product in products)
            {
                response.Add(new ChangeProductEntityResponse(
                    createdAt: product.CreatedAt, name: product.Name, price: product.Price, brand: product.Brand, updatedAt: product.UpdatedAt, id: product.Id
                ));
            }
            return response;
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <remarks>
        /// Exemple request:
        ///
        ///     GET /api/v1/products/1
        ///     
        /// </remarks>
        /// <param name="id">Product ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Product found</returns>
        /// <response code="200">Return product.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ChangeProductEntityResponse> GetProductById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(id, cancellationToken);

            return new ChangeProductEntityResponse(
                    createdAt: product.CreatedAt, name: product.Name, price: product.Price, brand: product.Brand, updatedAt: product.UpdatedAt, id: product.Id
                );
        }

        /// <summary>
        /// Insert new product
        /// </summary>
        /// <remarks>
        /// Exemple request:
        ///
        ///     POST /api/v1/products
        ///     {
        ///         Name = Car,
        ///         Price = 2500.00,
        ///         Brand = Ferrari
        ///     }
        /// </remarks>
        /// <param name="request">Object request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Product created</returns>
        /// <response code="200">Product created.</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ChangeProductEntityResponse> CreateNewProduct([FromBody] ChangeProductEntityRequest request, CancellationToken cancellationToken)
        {
            _productRepository.Add(new Product(name: request.Name, price: request.Price, brand: request.Brand));

            await _productRepository.Push(cancellationToken);

            var product = await _productRepository.GetLastProduct(cancellationToken);

            return new ChangeProductEntityResponse(
                    createdAt: product.CreatedAt, name: product.Name, price: product.Price, brand: product.Brand, updatedAt: product.UpdatedAt, id: product.Id
                );
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <remarks>
        /// Exemple request:
        ///
        ///     PUT /api/v1/products/1
        ///     {
        ///         Name = Car,
        ///         Price = 2500.00,
        ///         Brand = Ferrari
        ///     }
        /// </remarks>
        /// <param name="request">Object request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Product updated</returns>
        /// <response code="200">Product updated.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ChangeProductEntityResponse> UpdateProduct([FromRoute] int id, [FromBody] ChangeProductEntityRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(id, cancellationToken);

            product.Price = request.Price;
            product.Brand = request.Brand;
            product.Name = request.Name;

            _productRepository.Update(product);
            await _productRepository.Push(cancellationToken);

            return new ChangeProductEntityResponse(
                    createdAt: product.CreatedAt, name: product.Name, price: product.Price, brand: product.Brand, updatedAt: product.UpdatedAt, id: product.Id
                );
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <remarks>
        /// Exemple request:
        ///
        ///     DELETE /api/v1/products/1
        ///     
        /// </remarks>
        /// <param name="request">Object request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Product deleted</returns>
        /// <response code="200">Product deleted.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id, [FromBody] ChangeProductEntityRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(id, cancellationToken);

            _productRepository.Exclude(product);
            await _productRepository.Push(cancellationToken);

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
