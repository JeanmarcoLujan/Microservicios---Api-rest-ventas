using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioVentas.Search.Interfaces;

namespace ServicioVentas.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        private readonly IProductsService _producsService;
        private readonly ISalesServices _salesService;
        public SearchController(
            ICustomersService customersService,
            IProductsService productsService,
            ISalesServices salesServices
            )
        {
            _customersService = customersService;
            _producsService = productsService;
            _salesService = salesServices;

        }

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            try
            {
                var sales = await _salesService.GetAsync(customerId);
                var customer = await _customersService.GetAsync(customerId);
                

                

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await _producsService.GetAsync(item.ProductId);
                        item.Product = product;

                    }

                }

                var result = new
                {
                    Customer = customer,
                    Sales = sales

                };

                return Ok(result);

            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
