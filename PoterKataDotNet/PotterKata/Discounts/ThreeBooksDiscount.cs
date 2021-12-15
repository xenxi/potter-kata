namespace PotterKata.Discounts;

public class ThreeBooksDiscount : BooksDiscountCalculator
{
    private readonly BooksDiscountCalculator _nextDiscount;

    public ThreeBooksDiscount(BooksDiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IEnumerable<Book> books)
    {
        var numOfBooks = books.Count();
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 10);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 3;
}
