using ServicioVentas.Customers.Models;

namespace ServicioVentas.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> repo = new List<Customer>();  
        
        public CustomersProvider()
        {
            repo.Add(new Customer() { Id="1", Name="Juan", City="Trujillo"});
            repo.Add(new Customer() { Id = "2", Name = "Susan", City = "Huaraz" });
            repo.Add(new Customer() { Id = "3", Name = "Maria", City = "Lima" });
            repo.Add(new Customer() { Id = "4", Name = "Jorge", City = "Tumbes" });
            repo.Add(new Customer() { Id = "5", Name = "Jose", City = "Cusco" });
        }
        public Task<Customer> GetAsync(string id)
        {
            var customer = repo.FirstOrDefault(x => x.Id == id);    
            return Task.FromResult(customer);
        }
    }
}
