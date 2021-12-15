namespace PotterKata.Discounts;

public class TwoBooksDiscount : BooksDiscountCalculator
{
    private readonly BooksDiscountCalculator _nextDiscount;

    public TwoBooksDiscount(BooksDiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IEnumerable<Book> books)
    {
        var numOfBooks = books.Count();
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 5m);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 2;
}
