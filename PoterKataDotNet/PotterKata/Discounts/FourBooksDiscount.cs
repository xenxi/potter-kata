namespace PotterKata.Discounts;

public class FourBooksDiscount : BooksDiscountCalculator
{
    private readonly BooksDiscountCalculator _nextDiscount;

    public FourBooksDiscount(BooksDiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IEnumerable<Book> books)
    {
        var numOfBooks = books.Count();
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 20);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 4;
}
