using ServicioVentas.Sales.Models;

namespace ServicioVentas.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
