using System.Collections.Generic;
using TariffComparison.Domain.Entities;

namespace TariffComparison.Domain.Factories
{
    public interface IProductFactory
    {
        IEnumerable<IProductDomainEntity> Create(ITariffCalculationSettings calculationSettings, params TariffType[] types);
    }
}
