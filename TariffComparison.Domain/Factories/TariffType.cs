using System.ComponentModel;
using TariffComparison.Domain.Constants;

namespace TariffComparison.Domain.Factories
{
    public enum TariffType
    {
        [Description(ProductContants.BasicTarrifProductName)]
        Base,
        [Description(ProductContants.PackagedTariffProductName)]
        Package
    }
}
