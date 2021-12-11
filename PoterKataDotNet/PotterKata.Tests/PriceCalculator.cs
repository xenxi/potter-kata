namespace PotterKata.Tests;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(params string[] books)
    {
        if (books.Length > 1)
        {
            var subtotal = UnitPrice * books.Length;
            return subtotal - GetDiscount(subtotal);
        }

        return UnitPrice;
    }

    private static decimal GetDiscount(decimal price) => (price * 5) / 100;
}