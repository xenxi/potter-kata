using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests;

[TestFixture]
public class PriceCalculatorShould
{
    [TestCase("first_book")]
    [TestCase("second_book")]
    [TestCase("third_book")]
    [TestCase("fourth_book")]
    [TestCase("fith_book")]
    public void each_book_cost_eight(string book)
    {
        var shoppingCart = new ShoppingCart(book);

        var price = PriceCalculator.Calcule(shoppingCart);

        price.Should().Be(8);
    }


    [Test]
    public void two_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart("first_book", "second_book");

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(15.2m);
    }
    [Test]
    public void three_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart("first_book", "second_book", "third_book");

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(21.6m);
    }
    [Test]
    public void four_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart("first_book", "second_book", "third_book", "fourth_book");

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(25.6m);
    }
    [Test]
    public void five_different_books_have_a_right_discount()
    {
        var shoppingCart = new ShoppingCart("first_book", "second_book", "third_book", "fourth_book", "fith_book");

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(30m);
    }

    [Test]
    public void calcule_lowest_price()
    {
        var shoppingCart = new ShoppingCart("first_book", "second_book", "third_book", "fourth_book", "fith_book", "first_book");

        var priceWithDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithDiscount.Should().Be(38m);
    }
    [Test]
    public void two_units_of_the_same_book_has_not_discount()
    {
        var shoppingCart = new ShoppingCart("first_book", "first_book");

        var priceWithoutDiscount = PriceCalculator.Calcule(shoppingCart);

        priceWithoutDiscount.Should().Be(16);
    }



}
