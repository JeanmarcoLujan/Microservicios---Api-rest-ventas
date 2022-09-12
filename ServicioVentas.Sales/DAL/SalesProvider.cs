using ServicioVentas.Sales.Models;

namespace ServicioVentas.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();

        public SalesProvider()
        {
            repo.Add( new Order()
            {
                Id="0001",
                CustomerId = "2",
                OrderDate = DateTime.Now,
                Total = 100,
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        OrderId="0001",
                        Id=1,
                        Price = 50,
                        ProductId = "10",
                        Quantity = 2
                    }
                }
            });

        }
        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = repo.Where(c=> c.CustomerId == customerId).ToList();
            return Task.FromResult( (ICollection<Order>)orders);
        }
    }
}
