using PotterKata.Discounts;

namespace PotterKata;

public class PriceCalculator
{
    private static readonly BooksDiscountCalculator _discountCalculator = BooksDiscountCalculator.Create();

    public static decimal Calcule(ShoppingCart shoppingCart)
    {
        var books = shoppingCart.Books;
        var packs = CreatePacks(books);
        var total = CalculeTotal(packs);

        return total;
    }

    private static decimal CalculeTotal(List<BooksPack> packs) 
        => packs
        .Select(p => _discountCalculator.ApplyDiscount(p.NumOfBooks))
        .Sum();

    private static List<BooksPack> CreatePacks(IList<Book> books)
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

        var currentPrice = _discountCalculator.ApplyDiscount(pack.Books.Count);
        var nextPrice = _discountCalculator.ApplyDiscount(books.Count());

        return nextPrice - currentPrice;
    }
}