using TariffComparison.Domain.Entities;
using TariffComplarison.CalculationStrategies;

namespace TariffComplarison.Domain.Entities
{
    internal sealed class ProductDomainEntity: IProductDomainEntity
    {
        public string Name { get; private set; }
        public double Payment { get; private set; }

        private ITariffCalculationStrategy _tariffCalculationStrategy;

        internal ProductDomainEntity(string name, ITariffCalculationStrategy tariffCalculationStrategy)
        {
            Name = name;
            _tariffCalculationStrategy = tariffCalculationStrategy;
        }

        public void Calculate(int consumption)
        {
            Payment = _tariffCalculationStrategy.Calculate(consumption);
        }
    }
}