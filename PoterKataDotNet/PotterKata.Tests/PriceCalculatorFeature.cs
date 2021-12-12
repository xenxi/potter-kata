using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterKata.Tests
{
    [TestFixture]
    public class PriceCalculatorFeature
    {
        [Test]
        public void calcule_lowest_price()
        {
            var shoppingCart = new ShoppingCart("first_book", "second_book", "third_book", "fourth_book", "fith_book");

            var price = PriceCalculator.Calcule(shoppingCart);

            price.Should().Be(51.20m);
        }

    }
}
