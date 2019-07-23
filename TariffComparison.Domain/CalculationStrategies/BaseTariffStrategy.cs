using System;

namespace TariffComplarison.CalculationStrategies
{
    internal sealed class BaseTariffStrategy : ITariffCalculationStrategy
    {
        private readonly int _baseMonthCost;
        private readonly int _monthsInYear;
        private readonly double _consumptionCosts;

        private const string ArgumentIsNegativeExceptionMessage = "Consumption has to be a positive value";

        public BaseTariffStrategy(int baseMonthCost, int monthsInYear, double consumptionCosts)
        {
            _baseMonthCost = baseMonthCost;
            _monthsInYear = monthsInYear;
            _consumptionCosts = consumptionCosts;
        }

        public double Calculate(int consumption)
        {
            if (consumption < 0) throw new ArgumentOutOfRangeException(nameof(consumption), ArgumentIsNegativeExceptionMessage);
            return checked((_baseMonthCost * _monthsInYear) + (consumption * _consumptionCosts));
        }
           
    }
}