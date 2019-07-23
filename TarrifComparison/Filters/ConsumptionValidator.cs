using System.ComponentModel.DataAnnotations;

namespace TariffComparison.Api.Filters
{
    public sealed class ConsumptionValidator : ValidationAttribute
    {
        private const string ConsumptionIsNegativeExceptionMessage = "Consumption has to be a positive value";

        public ConsumptionValidator() : base(ConsumptionIsNegativeExceptionMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!int.TryParse(value.ToString(), out int consumption) || consumption < 0)
            {
                return new ValidationResult($"{FormatErrorMessage(validationContext?.DisplayName)}:{value}");
            }

            return ValidationResult.Success;
        }
    }
}
