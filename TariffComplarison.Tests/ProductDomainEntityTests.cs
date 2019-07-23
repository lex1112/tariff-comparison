using System;
using System.Linq;
using TariffComparison.Domain.Constants;
using TariffComparison.Domain.Entities;
using TariffComparison.Domain.Factories;
using Xunit;

namespace TariffComplarison.Tests
{
    public class ProductDomainEntityTests
    {
        private IProductDomainEntity _product;
        private IProductFactory _productFactory;

        private static readonly string ArgumentIsNegativeExceptionMessage = $"Consumption has to be a positive value{Environment.NewLine}Parameter name: consumption";
        
        public ProductDomainEntityTests()
        {

            var validator = new TariffCalculationSettingsValidator();
            _productFactory = new ElectricityProductFactory(validator);
        }

        internal void BasicTariffProductSetUp()
        {
            var calculationSettings = new TariffCalculationSettings();
            _product = _productFactory.Create(calculationSettings, TariffType.Base).FirstOrDefault();
        }


        internal void PackageTariffProductSetUp()
        {
            var calculationSettings = new TariffCalculationSettings();
            _product = _productFactory.Create(calculationSettings, TariffType.Package).FirstOrDefault();
        }

        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(6000, 1380)]
        public void Calculate_IfBasicTariff_ConsumptionIsCorrect_ExpectedResult(int consumption, int expectedResult)
        {
            BasicTariffProductSetUp();

            _product.Calculate(consumption);

            Assert.Equal(expectedResult, _product.Payment);
            Assert.Equal(ProductContants.BasicTarrifProductName, _product.Name);
        }

        [Theory]
        [InlineData(-3500)]
        [InlineData(-4500)]
        [InlineData(-6000)]
        public void Calculate_IfBasicTariff_ConsumptionIsNegativeValue_ArgumentOutOfRangeException(int consumption)
        {
            BasicTariffProductSetUp();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _product.Calculate(consumption));

            Assert.Equal(ArgumentIsNegativeExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(6000, 1400)]
        public void Calculate_IfPackageTariff_ConsumptionIsCorrect_ExpectedResult(int consumption, int expectedResult)
        {
            PackageTariffProductSetUp();

            _product.Calculate(consumption);

            Assert.Equal(expectedResult, _product.Payment);
            Assert.Equal(ProductContants.PackagedTariffProductName, _product.Name);
        }

        [Theory]
        [InlineData(-3500)]
        [InlineData(-4500)]
        [InlineData(-6000)]
        public void Calculate_IfPackageTariff_ConsumptionIsNegativeValue_ArgumentOutOfRangeException(int consumption)
        {
            BasicTariffProductSetUp();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _product.Calculate(consumption));

            Assert.Equal(ArgumentIsNegativeExceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData(2147483645, 3500)]
        [InlineData(2147483645, 4500)]
        [InlineData(2147483645, 6000)]
        public void Calculate_IfBaseTariff_BaseMonthCostCloseToMaxInt_ThrowOverflowException(int baseCost, int consumption)
        {
            var validator = new TariffCalculationSettingsValidator();
            var settings = new TariffCalculationSettings(baseMonthCost: baseCost);

            _productFactory = new ElectricityProductFactory(validator);
            _product = _productFactory.Create(settings, TariffType.Base).FirstOrDefault();

            Assert.Throws<OverflowException>(() => _product.Calculate(consumption));
        }
    }
}
