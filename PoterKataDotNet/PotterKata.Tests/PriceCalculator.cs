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
                var discount = GetDiscount(subtotal);
                return subtotal - discount;
            }

            return UnitPrice;
        }

        private static decimal GetDiscount(decimal price) => (price * 5) / 100;
    }
}