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

    private static decimal CalculeTotal(List<UniqueBooksPack> packs)
        => packs
        .Select(p => _discountCalculator.ApplyDiscount(p.NumOfBooks))
        .Sum();

    private static List<UniqueBooksPack> CreatePacks(IList<Book> books)
    {
        var booksPacks = new List<UniqueBooksPack>();

        foreach (var book in books)
            AddBook(booksPacks, book);

        return booksPacks;
    }

    private static void AddBook(List<UniqueBooksPack> booksPacks, Book book)
    {
        var candidates = booksPacks.Where(p => p.CanAdd(book));
        if (candidates.Any())
        {
            var bookPack = candidates.OrderBy(p => NextPrice(p, book)).First();
            bookPack.Add(book);
        }
        else
        {
            var bookPack = new UniqueBooksPack();
            bookPack.Add(book);
            booksPacks.Add(bookPack);
        }
    }

    private static decimal NextPrice(UniqueBooksPack pack, Book nextBook)
    {
        var currentPrice = _discountCalculator.ApplyDiscount(pack.NumOfBooks);
        var nextPrice = _discountCalculator.ApplyDiscount(pack.NumOfBooks + 1);

        return nextPrice - currentPrice;
    }
}