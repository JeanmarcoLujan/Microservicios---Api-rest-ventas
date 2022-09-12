using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Interfaces
{
    public interface IProductsService
    {
        Task<Product> GetAsync(string id);
    }
}
