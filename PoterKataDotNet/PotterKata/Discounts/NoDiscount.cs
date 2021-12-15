namespace PotterKata.Discounts;

public class NoDiscount : DiscountCalculator
{
    public override decimal ApplyDiscount(IEnumerable<Book> books) => CalculeSubtotal(books.Count());
}
