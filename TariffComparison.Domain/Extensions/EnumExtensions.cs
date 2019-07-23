using System.ComponentModel;

namespace TariffComparison.Domain.Factories
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this TariffType type)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])type
               .GetType()
               .GetField(type.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
