namespace PotterKata.Discounts;

public abstract class Discount
{
    private const decimal UnitPrice = 8;

    public abstract decimal ApplyDiscount(IList<Book> books);

    protected decimal CalculePriceWithDiscount(decimal subtotal, decimal discountRate) => subtotal - CalculeDiscount(subtotal, discountRate);

    protected decimal CalculeSubtotal(int numberOfBooks) => numberOfBooks * UnitPrice;

    private decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;
}

public class FourBooksDiscount : Discount
{
    private readonly Discount _nextDiscount;

    public FourBooksDiscount(Discount nextDiscount) => _nextDiscount = nextDiscount;

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

public class NoDiscount : Discount
{
    public override decimal ApplyDiscount(IList<Book> books) => CalculeSubtotal(books.Count);
}

public class ThreeBooksDiscount : Discount
{
    private readonly Discount _nextDiscount;

    public ThreeBooksDiscount(Discount nextDiscount) => _nextDiscount = nextDiscount;

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

public class TwoBooksDiscount : Discount
{
    private readonly Discount _nextDiscount;

    public TwoBooksDiscount(Discount nextDiscount) => _nextDiscount = nextDiscount;

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
public class FiveBooksDiscount : Discount
{
    private readonly Discount _nextDiscount;

    public FiveBooksDiscount(Discount nextDiscount) => _nextDiscount = nextDiscount;

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