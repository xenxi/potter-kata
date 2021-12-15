namespace PotterKata.Discounts;

public class FiveBooksDiscount : BooksDiscountCalculator
{
    private readonly BooksDiscountCalculator _nextDiscount;

    public FiveBooksDiscount(BooksDiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(int numOfBooks)
    {
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(numOfBooks);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 25);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 5;
}