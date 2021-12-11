using System.Linq;

namespace PotterKata.Tests;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(params string[] books)
    {
        if (JustOneBook(books)) return UnitPrice * books.Length;

        return ApplyDiscount(books.Length);
    }

    private static decimal ApplyDiscount(int numberOfBooks)
    {
        var subtotal = UnitPrice * numberOfBooks;
        return subtotal - CalculeDiscount(subtotal);
    }

    private static decimal CalculeDiscount(decimal price) => (price * 5) / 100;

    private static bool JustOneBook(string[] books) => books.Distinct().Count() <= 1;
}