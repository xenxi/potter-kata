namespace PotterKata.Discounts;

public class NoDiscount : DiscountCalculator
{
    public override decimal ApplyDiscount(IList<Book> books) => CalculeSubtotal(books.Count);
}
