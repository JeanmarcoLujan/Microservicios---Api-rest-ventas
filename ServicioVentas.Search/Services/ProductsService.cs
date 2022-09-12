using Newtonsoft.Json;
using ServicioVentas.Search.Interfaces;
using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<Product> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productsService");

            var response = await client.GetAsync($"api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();   
                var product = JsonConvert.DeserializeObject<Product>(content);
                return product;
            }
            return null;
        }
    }
}
