using System;

namespace TariffComplarison.CalculationStrategies
{
    internal sealed class PackageTariffStrategy : ITariffCalculationStrategy
    {

        private readonly int _thresholdConsumption;
        private readonly int _baseCost;
        private readonly double _additionalConsumptionCosts;

        private const string ArgumentIsNegativeExceptionMessage = "Consumption has to be a positive value";

        public PackageTariffStrategy(int thresholdConsumption, int baseCost, double additionalConsumptionCosts)
        {
            _thresholdConsumption = thresholdConsumption;
            _baseCost = baseCost;
            _additionalConsumptionCosts = additionalConsumptionCosts;
        }

        public double Calculate(int consumption)
        {
           if (consumption < 0) throw new ArgumentOutOfRangeException(nameof(consumption), ArgumentIsNegativeExceptionMessage);
            return checked(_baseCost + (_additionalConsumptionCosts * Math.Max(0, consumption - _thresholdConsumption)));
        }
    }
}