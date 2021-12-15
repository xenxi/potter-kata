namespace PotterKata.Discounts;

public abstract class BooksDiscountCalculator
{
    private const decimal UnitPrice = 8;

    public static BooksDiscountCalculator Create()
    {
        var noDiscount = new NoDiscount();
        var TwoBooksDiscount = new TwoBooksDiscount(noDiscount);
        var threeBooksDiscount = new ThreeBooksDiscount(TwoBooksDiscount);
        var fourBooksDiscount = new FourBooksDiscount(threeBooksDiscount);
        var fiveBooksDiscount = new FiveBooksDiscount(fourBooksDiscount);
        return fiveBooksDiscount;
    }

    public abstract decimal ApplyDiscount(int numOfBooks);

    protected decimal CalculePriceWithDiscount(decimal subtotal, decimal discountRate) => subtotal - CalculeDiscount(subtotal, discountRate);

    protected decimal CalculeSubtotal(int numberOfBooks) => numberOfBooks * UnitPrice;

    private decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;
}
