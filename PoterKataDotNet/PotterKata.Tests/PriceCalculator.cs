namespace PotterKata.Tests;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(params string[] books)
    {
        if (JustOneBook(books)) return UnitPrice;

        var subtotal = UnitPrice * books.Length;
        return subtotal - GetDiscount(subtotal);
    }

    private static bool JustOneBook(string[] books) => books.Length <= 1;

    private static decimal GetDiscount(decimal price) => (price * 5) / 100;
}