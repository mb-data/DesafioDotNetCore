using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace APIDesafioDotNetCore.OT.ChangeProductEntity.Response
{
    public sealed class ChangeProductEntityResponse
    {
        /// <summary>
        /// Init a <see cref="ChangeProductEntityResponse"/> object
        /// </summary>
        /// <param name="createdAt">Project criation date</param>
        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        /// <param name="brand">Product brand</param>
        /// <param name="updatedAt">Project update date</param>
        /// <param name="id">Product ID</param>
        public ChangeProductEntityResponse(DateTime createdAt, string name, decimal price, string brand, DateTime updatedAt, int id)
        {
            CreatedAt = createdAt;
            Name = name;
            Price = price;
            Brand = brand;
            UpdatedAt = updatedAt;
            Id = id;
        }

        /// <summary>
        /// Object criation date
        /// </summary>
        [Required, JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Required, JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        [Required, JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Product brand
        /// </summary>
        [Required, JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// Object update date
        /// </summary>
        [Required, JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        [Required, JsonProperty("id")]
        public int Id { get; set; }
    }
}