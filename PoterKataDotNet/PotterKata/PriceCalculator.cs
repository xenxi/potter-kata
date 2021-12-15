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
        var booksPacks = new List<BooksPack>(); 
        foreach (var book in books)
        {
            var candidates = booksPacks.Where(p => p.CanAdd(book));
            if (candidates.Any())
            {
                var bookPack = candidates.OrderBy(p => NextPrice(p, book)).First();
                bookPack.Add(book);
            }
            else 
            {
                var bookPack = new BooksPack();
                bookPack.Add(book);
                booksPacks.Add(bookPack);
            }

        }

        return booksPacks.Select(p => p.Books.ToList()).ToList();
    }

    private static decimal NextPrice(BooksPack pack, Book nextBook)
    {
        var books = pack.Books.Append(nextBook);

       var currentPrice = _discountCalculator.ApplyDiscount(pack.Books);
       var nextPrice = _discountCalculator.ApplyDiscount(books);

        return nextPrice - currentPrice;
    }
}
