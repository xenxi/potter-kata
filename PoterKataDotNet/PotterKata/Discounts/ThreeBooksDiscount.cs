namespace PotterKata.Discounts;

public class ThreeBooksDiscount : DiscountCalculator
{
    private readonly DiscountCalculator _nextDiscount;

    public ThreeBooksDiscount(DiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IList<Book> books)
    {
        var numOfBooks = books.Count;
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 10);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 3;
}
