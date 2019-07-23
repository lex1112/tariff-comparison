namespace TariffComparison.Domain.Factories
{
    public class TariffCalculationSettings : ITariffCalculationSettings
    {
        static class DefaultValues
        {
            public const int ThresholdConsumption = 4000;
            public const int BaseCost = 800;
            public const double AdditionalConsumptionCosts = 0.3;

            public const int BaseMonthCost = 5;
            public const int MonthsInYear = 12;
            public const double ConsumptionCosts = 0.22;
        }

        public int ThresholdConsumption { get; private set; }
        public int BaseCost { get; private set; }
        public double AdditionalConsumptionCosts { get; private set; }

        public int BaseMonthCost { get; private set; }
        public int MonthsInYear { get; private set; }
        public double ConsumptionCosts { get; private set; }

        public TariffCalculationSettings(
            int? thresholdConsumption = DefaultValues.ThresholdConsumption,
            int? baseCost = DefaultValues.BaseCost,
            double? additionalConsumptionCosts = DefaultValues.AdditionalConsumptionCosts,
            int? baseMonthCost = DefaultValues.BaseMonthCost,
            int? monthsInYear = DefaultValues.MonthsInYear,
            double? consumptionCosts = DefaultValues.ConsumptionCosts)
        {
            ThresholdConsumption = thresholdConsumption.Value;
            BaseCost = baseCost.Value;
            AdditionalConsumptionCosts = additionalConsumptionCosts.Value;

            BaseMonthCost = baseMonthCost.Value;
            MonthsInYear = monthsInYear.Value;
            ConsumptionCosts = consumptionCosts.Value;
        }


    }
}
