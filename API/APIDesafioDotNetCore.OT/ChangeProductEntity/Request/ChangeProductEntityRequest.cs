using APIDesafioDotNetCore.OT.Base.Request;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace APIDesafioDotNetCore.OT.ChangeProductEntity.Request
{
    public sealed class ChangeProductEntityRequest : BaseRequest
    {
        /// <summary>
        /// Init a <see cref="ChangeProductEntityRequest"/> object
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="price">Product price</param>
        /// <param name="brand">Product brand</param>
        public ChangeProductEntityRequest(string name, decimal price, string brand)
        {
            Name = name;
            Price = price;
            Brand = brand;
        }

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

    }
}