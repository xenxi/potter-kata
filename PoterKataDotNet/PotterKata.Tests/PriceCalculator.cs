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
        return subtotal - CalculeDiscount(subtotal, GetApplicableDiscount(numberOfBooks));
    }

    private static int GetApplicableDiscount(int numberOfBooks)
    {
        if (numberOfBooks == 3)
            return 10;
        if (numberOfBooks == 4)
            return 20;
        return 5;
    }

    private static decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;

    private static bool JustOneBook(string[] books) => books.Distinct().Count() <= 1;
}