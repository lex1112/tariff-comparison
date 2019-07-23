using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TariffComparison.Api.Filters;
using TariffComparison.Api.Services;
using TarrifComparison.Models;

namespace TarrifComparison.Controllers
{
    [Route("api/tariff-comparison")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IProductService _productService;

        public IndexController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/tariff-comparison/350
        [HttpGet("{consumption}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductViewModel>))]
        public async Task<IActionResult> Get([ConsumptionValidator]int consumption)
        {
            return Ok(await _productService.Get(consumption));
        }
    }
}
