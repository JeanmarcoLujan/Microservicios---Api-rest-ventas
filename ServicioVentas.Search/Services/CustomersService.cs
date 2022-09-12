using Newtonsoft.Json;
using ServicioVentas.Search.Interfaces;
using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetAsync(string id)
        {
            var client = httpClientFactory.CreateClient("customersService");
            var response = await client.GetAsync($"api/Customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;
            }

            return null;
        }
    }
}
