using APIDesafioDotNetCore.BancoDeDados.Entities;

namespace APIDesafioDotNetCore.BancoDeDados.Entidades
{
    /// <summary>
    /// Product entity
    /// </summary>
    public class Product : EntityBase
    {
        /// <summary>
        /// Init a <see cref="Product"/> object
        /// </summary>
        /// <param name="createdAt">Product criation date</param>
        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        /// <param name="brand">Product brand</param>
        /// <param name="updatedAt">Product update date</param>
        /// <param name="id">Product ID</param>
        public Product(DateTime createdAt, string name, decimal price, string brand, DateTime updatedAt, int id)
            : base(createdAt, updatedAt)
        {
            Name = name;
            Price = price;
            Brand = brand;
            Id = id;
        }

        public Product(string name, decimal price, string brand)
            : base(new DateTime(), new DateTime())
        {
            Name = name;
            Price = price;
            Brand = brand;
        }



        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        public int Id { get; set; }
    }
}
