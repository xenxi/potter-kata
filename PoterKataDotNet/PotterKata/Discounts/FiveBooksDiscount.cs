﻿namespace PotterKata.Discounts;

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