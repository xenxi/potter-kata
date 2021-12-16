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
        var packWithTheBestDiscount = SearchPackWithTheBestDiscount(booksPacks, book);
        if (packWithTheBestDiscount == null)
        {
            packWithTheBestDiscount = new UniqueBooksPack();
            booksPacks.Add(packWithTheBestDiscount);
        }
        packWithTheBestDiscount.Add(book);
    }

    private static UniqueBooksPack? SearchPackWithTheBestDiscount(List<UniqueBooksPack> booksPacks, Book book)
    {
        var packsWithoutTheBook = booksPacks.Where(p => p.CanAdd(book));
        return packsWithoutTheBook
                .OrderBy(p => CalculePriceIncrement(p, book))
                .FirstOrDefault();
    }

    private static decimal CalculePriceIncrement(UniqueBooksPack pack, Book nextBook)
    {
        var currentPrice = _discountCalculator.ApplyDiscount(pack.NumOfBooks);
        var nextPrice = _discountCalculator.ApplyDiscount(pack.NumOfBooks + 1);

        return nextPrice - currentPrice;
    }
}