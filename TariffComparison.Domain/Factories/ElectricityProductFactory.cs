using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Domain.Entities;
using TariffComplarison.CalculationStrategies;
using TariffComplarison.Domain.Entities;

namespace TariffComparison.Domain.Factories
{
    public class ElectricityProductFactory : IProductFactory
    {

        private readonly AbstractValidator<ITariffCalculationSettings> _settingsValidator;

        public ElectricityProductFactory(AbstractValidator<ITariffCalculationSettings> settingsValidator)
        {
            _settingsValidator = settingsValidator;
        }

        public IEnumerable<IProductDomainEntity> Create(ITariffCalculationSettings calculationSettings, params TariffType[] types)
        {
            var validateResult = _settingsValidator.Validate(calculationSettings);

            if (!validateResult.IsValid)
                throw new ArgumentException(string.Join($"{Environment.NewLine}", validateResult.Errors));
                

            var tariffTypeMap =
                     new Dictionary<TariffType, ITariffCalculationStrategy>
                    {
                        { TariffType.Base,
                             new BaseTariffStrategy(
                                 calculationSettings.BaseMonthCost,
                                 calculationSettings.MonthsInYear,
                                 calculationSettings.ConsumptionCosts)
                         },

                        { TariffType.Package,
                             new PackageTariffStrategy(
                                 calculationSettings.ThresholdConsumption,
                                 calculationSettings.BaseCost,
                                 calculationSettings.AdditionalConsumptionCosts
                                 )
                         }
                    };

            return types.Select(type => new ProductDomainEntity(type.ToDescriptionString(), tariffTypeMap[type]));
        }
    }
}
