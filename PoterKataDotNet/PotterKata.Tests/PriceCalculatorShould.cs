using FluentAssertions;
using NUnit.Framework;

namespace PotterKata.Tests
{
    [TestFixture]
    public class PriceCalculatorShould
    {
        [TestCase("first_book")]
        [TestCase("second_book")]
        [TestCase("third_book")]
        [TestCase("fourth_book")]
        [TestCase("fith_book")]
        [TestCase("sixth_book")]
        [TestCase("seventh_book")]
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
    }
}
