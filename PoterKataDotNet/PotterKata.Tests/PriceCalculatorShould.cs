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
        var price = PriceCalculator.Calcule(book);

        price.Should().Be(8);
    }


    [Test]
    public void two_different_books_have_a_right_discount()
    {
        var priceWithDiscount = PriceCalculator.Calcule("first_book", "second_book");

        priceWithDiscount.Should().Be(15.2m);
    }
    [Test]
    public void three_different_books_have_a_right_discount()
    {
        var priceWithDiscount = PriceCalculator.Calcule("first_book", "second_book", "third_book");

        priceWithDiscount.Should().Be(21.6m);
    }
    [Test]
    public void two_units_of_the_same_book_has_not_discount()
    {
        var priceWithoutDiscount = PriceCalculator.Calcule("first_book", "first_book");

        priceWithoutDiscount.Should().Be(16);
    }



}
