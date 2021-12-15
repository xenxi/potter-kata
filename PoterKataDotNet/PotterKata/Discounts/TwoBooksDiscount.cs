namespace PotterKata.Discounts;

public class TwoBooksDiscount : DiscountCalculator
{
    private readonly DiscountCalculator _nextDiscount;

    public TwoBooksDiscount(DiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IList<Book> books)
    {
        var numOfBooks = books.Count;
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 5m);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 2;
}
