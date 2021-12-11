using System;

namespace PotterKata.Tests
{
    public class PriceCalculator
    {
        private const decimal UnitPrice = 8;

        public static decimal Calcule(params string[] books)
        {
            if (books.Length > 1)
            {
                var subtotal = UnitPrice * books.Length;
                var discount = (subtotal * 5) / 100;
                return subtotal - discount;
            }

            return UnitPrice;
        }
    }
}