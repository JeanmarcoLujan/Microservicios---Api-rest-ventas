using ServicioVentas.Products.Models;

namespace ServicioVentas.Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string id);
    }
}
