using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests;

[TestFixture]
public class PriceCalculatorFeature
{
    [Test]
    public void calcule_lowest_price()
    {
        var shoppingCart = new ShoppingCart(Book.First, Book.First, Book.Second, Book.Second, Book.Third, Book.Third, Book.Fourth, Book.Fith);

        var price = PriceCalculator.Calcule(shoppingCart);

        price.Should().Be(51.20m);
    }

}
