using PotterKata.Discounts;

namespace PotterKata;

public class PriceCalculator
{
    private static readonly BooksDiscountCalculator _discountCalculator = BooksDiscountCalculator.Create();

    public static decimal Calcule(ShoppingCart shoppingCart)
    {
        var books = shoppingCart.Books;

        var packs = GetPacks(books).Select(p => p.Books);
        var total = 0m;
        foreach (var pack in packs)
        {
            total += _discountCalculator.ApplyDiscount(pack);
        }

        return total;
    }

    private static List<BooksPack> GetPacks(IList<Book> books)
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

        return booksPacks;
    }

    private static decimal NextPrice(BooksPack pack, Book nextBook)
    {
        var books = pack.Books.Append(nextBook);

       var currentPrice = _discountCalculator.ApplyDiscount(pack.Books);
       var nextPrice = _discountCalculator.ApplyDiscount(books);

        return nextPrice - currentPrice;
    }
}
