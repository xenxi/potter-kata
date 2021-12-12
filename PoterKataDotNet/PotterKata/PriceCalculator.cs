namespace PotterKata;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(ShoppingCart shoppingCart)
    {
        var books = shoppingCart.Books;

        var packs = GetPacks(books);
        var total = 0m;
        foreach (var pack in packs)
        {
            total += ApplyDiscount(pack.ToArray());
        }

        return total;
    }

    private static decimal ApplyDiscount(Book[] books)
    {
        if (JustOneBook(books)) return UnitPrice * books.Length;

        return ApplyDiscount(books.Length);
    }

    private static decimal ApplyDiscount(int numberOfBooks)
    {
        var subtotal = UnitPrice * numberOfBooks;
        return subtotal - CalculeDiscount(subtotal, GetApplicableDiscount(numberOfBooks));
    }

    private static decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;

    private static int GetApplicableDiscount(int numberOfBooks)
    {
        if (numberOfBooks == 3)
            return 10;
        if (numberOfBooks == 4)
            return 20;
        if (numberOfBooks == 5)
            return 25;
        return 5;
    }

    private static IEnumerable<IEnumerable<Book>> GetPacks(IList<Book> books)
    {
        var test = books.ToList();

        var group = test.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var result = new List<IEnumerable<Book>>();
        while (group.Values.Sum() > 0)
        {
            var aux = new List<Book>();
            foreach (var dataPack in group)
            {
                if (dataPack.Value > 0)
                {
                    aux.Add(dataPack.Key);
                    group[dataPack.Key]--;
                }
            }
            result.Add(aux);
        }
        return result;
    }
    private static bool JustOneBook(Book[] books) => books.Distinct().Count() <= 1;
}