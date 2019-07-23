using System.Collections.Generic;
using System.Threading.Tasks;
using TarrifComparison.Models;

namespace TariffComparison.Api.Services
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductViewModel>> Get(int consumption);
    }
}
