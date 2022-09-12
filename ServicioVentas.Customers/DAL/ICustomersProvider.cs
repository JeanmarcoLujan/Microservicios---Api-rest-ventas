using ServicioVentas.Customers.Models;

namespace ServicioVentas.Customers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
    }
}
