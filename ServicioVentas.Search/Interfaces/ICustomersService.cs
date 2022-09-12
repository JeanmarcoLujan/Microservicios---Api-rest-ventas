using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Interfaces
{
    public interface ICustomersService
    {
        Task<Customer> GetAsync(string id);
    }
}
