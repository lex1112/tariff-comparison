using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Domain.Factories;
using TarrifComparison.Models;

namespace TariffComparison.Api.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductFactory _productFactory;
        private readonly ITariffCalculationSettings _calculationSettings;

        public ProductService(IProductFactory productFactory, ITariffCalculationSettings calculationSettings)
        {
            _calculationSettings = calculationSettings;
            _productFactory = productFactory;
        }

        public async Task<IReadOnlyCollection<ProductViewModel>> Get(int consumption)
        {
            var products = await Task.Run(() =>
            {
                var domainProducts = _productFactory.Create(_calculationSettings, TariffType.Base, TariffType.Package).ToList();
                domainProducts.ForEach(p => p.Calculate(consumption));
                return domainProducts;
            });

            return products.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Payment = p.Payment
            }).ToList();
        }
    }
}
