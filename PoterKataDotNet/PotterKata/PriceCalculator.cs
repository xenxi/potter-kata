using PotterKata.Discounts;

namespace PotterKata;

public class PriceCalculator
{
    private static readonly DiscountCalculator _discountCalculator = DiscountCalculator.Create();

    public static decimal Calcule(ShoppingCart shoppingCart)
    {
        var books = shoppingCart.Books;

        var packs = GetPacks(books);
        var total = 0m;
        foreach (var pack in packs)
        {
            total += _discountCalculator.ApplyDiscount(pack);
        }

        return total;
    }

    private static List<List<Book>> GetPacks(IList<Book> books)
    {
        var test = books.ToList();

        var group = test.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        var result = new List<List<Book>>();
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
        return OptimizeDiscounts(result);
    }

    private static List<List<Book>> OptimizeDiscounts(List<List<Book>> result)
    {
        while (result.Any(x => x.Count == 5) && result.Any(x => x.Count == 3))
        {
            var fivePack = result.First(p => p.Count == 5);
            var threePack = result.First(p => p.Count == 3);

            var book = fivePack.First(b => !threePack.Contains(b));

            fivePack.Remove(book);
            threePack.Add(book);
        }

        return result;
    }
}