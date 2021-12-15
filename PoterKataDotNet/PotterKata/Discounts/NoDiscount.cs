namespace PotterKata.Discounts;

public class NoDiscount : BooksDiscountCalculator
{
    public override decimal ApplyDiscount(IEnumerable<Book> books) => CalculeSubtotal(books.Count());
}
