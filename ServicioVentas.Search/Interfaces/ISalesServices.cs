using ServicioVentas.Search.Models;

namespace ServicioVentas.Search.Interfaces
{
    public interface ISalesServices
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
