using FluentValidation;

namespace TariffComparison.Domain.Factories
{
    public class TariffCalculationSettingsValidator : AbstractValidator<ITariffCalculationSettings>
    {
        public TariffCalculationSettingsValidator()
        {
            RuleFor(x => x.AdditionalConsumptionCosts).GreaterThan(0);
            RuleFor(x => x.BaseCost).GreaterThan(0);
            RuleFor(x => x.BaseMonthCost).GreaterThan(0);
            RuleFor(x => x.ConsumptionCosts).GreaterThan(0);
            RuleFor(x => x.MonthsInYear).GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(x => x.ThresholdConsumption).GreaterThan(0);
        }
    }
}
