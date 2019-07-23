namespace TariffComparison.Domain.Factories
{
    public interface ITariffCalculationSettings
    {
        int ThresholdConsumption { get;}
        int BaseCost { get;}
        double AdditionalConsumptionCosts { get; }

        int BaseMonthCost { get; }
        int MonthsInYear { get;}
        double ConsumptionCosts { get; }
    }
}
