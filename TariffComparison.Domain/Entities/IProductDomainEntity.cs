namespace TariffComparison.Domain.Entities
{
    public interface IProductDomainEntity
    {
        double Payment { get; }

        string Name { get; }

        void Calculate(int consumption);
    }
}