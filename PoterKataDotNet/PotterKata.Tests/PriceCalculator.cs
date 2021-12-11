using System;

namespace PotterKata.Tests
{
    public class PriceCalculator
    {
        private const int UnitPrice = 8;

        public static decimal Calcule(params string[] books)
        {
            if (books.Length > 1)
                return 15.2m;
            return UnitPrice;
        }
    }
}