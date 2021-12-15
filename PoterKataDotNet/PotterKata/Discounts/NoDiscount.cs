namespace PotterKata.Discounts;

public class NoDiscount : BooksDiscountCalculator
{
    public override decimal ApplyDiscount(int numOfBooks) => CalculeSubtotal(numOfBooks);
}