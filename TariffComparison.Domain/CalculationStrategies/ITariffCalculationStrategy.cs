namespace TariffComplarison.CalculationStrategies
{
    internal interface ITariffCalculationStrategy
    {
        double Calculate(int consumption);
    }
}