using APIDesafioDotNetCore.OT.ChangeProductEntity.Request;
using FluentAssertions;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace APIDesafioDotNetCore.Tests
{
    [TestFixture]
    internal sealed class ProductControllerTests : TestBase
    {
        [Test]
        public async Task GetAllProductsTest()
        {
            using var client = Server.CreateClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/products");

            var response = await client.SendAsync(request, CancellationToken.None);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test, TestCase("Car", 2500.00, "Ferrari")]
        public async Task ProductCreationTest(string name, decimal price, string brand)
        {
            var productRequest = new ChangeProductEntityRequest(name, price, brand);

            using var client = Server.CreateClient();
            using var body = new StringContent(productRequest.ToString(), Encoding.UTF8, MediaTypeNames.Application.Json);
            using var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1/products");
            request.Content = body;

            var response = await client.SendAsync(request, CancellationToken.None);
            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}