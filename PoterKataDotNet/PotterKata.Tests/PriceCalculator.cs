﻿using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Tests;

public class PriceCalculator
{
    private const decimal UnitPrice = 8;

    public static decimal Calcule(ShoppingCart shoppingCart)
    {
        return Calcule(shoppingCart.Books);
    }

    public static decimal Calcule(params string[] books)
    {
        var i = 0;
        IEnumerable<string> currentBooks;
        decimal total = 0;
        do
        {
            currentBooks = books.Skip(5 * i++).Take(5);
            total += ApplyDiscount(currentBooks.ToArray());
        } while (currentBooks.Any());

        return total;
    }

    private static decimal ApplyDiscount(string[] books)
    {
        if (JustOneBook(books)) return UnitPrice * books.Length;

        return ApplyDiscount(books.Length);
    }

    private static decimal ApplyDiscount(int numberOfBooks)
    {
        var subtotal = UnitPrice * numberOfBooks;
        return subtotal - CalculeDiscount(subtotal, GetApplicableDiscount(numberOfBooks));
    }

    private static int GetApplicableDiscount(int numberOfBooks)
    {
        if (numberOfBooks == 3)
            return 10;
        if (numberOfBooks == 4)
            return 20;
        if (numberOfBooks == 5)
            return 25;
        return 5;
    }

    private static decimal CalculeDiscount(decimal price, decimal discountRate) => price * discountRate / 100;

    private static bool JustOneBook(string[] books) => books.Distinct().Count() <= 1;
}