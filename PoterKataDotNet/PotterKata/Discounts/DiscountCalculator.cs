namespace PotterKata.Discounts;

public abstract class DiscountCalculator
{
    private const decimal UnitPrice = 8;

    public static DiscountCalculator Create()
    {
        var noDiscount = new NoDiscount();
        var TwoBooksDiscount = new TwoBooksDiscount(noDiscount);
        var threeBooksDiscount = new ThreeBooksDiscount(TwoBooksDiscount);
        var fourBooksDiscount = new FourBooksDiscount(threeBooksDiscount);
        var fiveBooksDiscount = new FiveBooksDiscount(fourBooksDiscount);
        return fiveBooksDiscount;
    }

    public abstract decimal ApplyDiscount(IList<Book> books);

    protected decimal CalculePriceWithDiscount(decimal subtotal, decimal discountRate) => subtotal - CalculeDiscount(subtotal, discountRate);

    protected decimal CalculeSubtotal(int numberOfBooks) => numberOfBooks * UnitPrice;

    private decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;
}

public class FourBooksDiscount : DiscountCalculator
{
    private readonly DiscountCalculator _nextDiscount;

    public FourBooksDiscount(DiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IList<Book> books)
    {
        var numOfBooks = books.Count;
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 20);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 4;
}

public class NoDiscount : DiscountCalculator
{
    public override decimal ApplyDiscount(IList<Book> books) => CalculeSubtotal(books.Count);
}

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

public class FiveBooksDiscount : DiscountCalculator
{
    private readonly DiscountCalculator _nextDiscount;

    public FiveBooksDiscount(DiscountCalculator nextDiscount) => _nextDiscount = nextDiscount;

    public override decimal ApplyDiscount(IList<Book> books)
    {
        var numOfBooks = books.Count;
        if (!ApplicableDiscount(numOfBooks))
            return _nextDiscount.ApplyDiscount(books);

        var subTotal = CalculeSubtotal(numOfBooks);
        return CalculePriceWithDiscount(subTotal, 25);
    }

    private static bool ApplicableDiscount(int numOfBooks) => numOfBooks == 5;
}