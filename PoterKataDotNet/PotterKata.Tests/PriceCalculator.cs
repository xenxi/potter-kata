namespace PotterKata.Tests;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(params string[] books)
    {
        if (JustOneBook(books)) return UnitPrice;

        return ApplyDiscount(books.Length);
    }

    private static decimal ApplyDiscount(int numberOfBooks)
    {
        var subtotal = UnitPrice * numberOfBooks;
        return subtotal - GetDiscount(subtotal);
    }

    private static decimal GetDiscount(decimal price) => (price * 5) / 100;

    private static bool JustOneBook(string[] books) => books.Length <= 1;
}