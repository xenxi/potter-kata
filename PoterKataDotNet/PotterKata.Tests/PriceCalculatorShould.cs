using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class PriceCalculatorShould
    {
        [Test]
        public void each_book_cost_eight()
        { 
            var price = PriceCalculator.Calcule("anyBook");

            price.Should().Be(8);
        }
    }
}
