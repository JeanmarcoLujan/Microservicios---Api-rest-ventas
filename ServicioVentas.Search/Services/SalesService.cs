using Newtonsoft.Json;
using ServicioVentas.Search.Interfaces;
using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Services
{
    public class SalesService: ISalesServices
    {

        private readonly IHttpClientFactory httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = httpClientFactory.CreateClient("salesService");
            var response = await client.GetAsync($"api/sales/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();   
                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(content);
                return orders;
            }
            return null;
        }
    }
}
