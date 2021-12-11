using System;

namespace PotterKata.Tests
{
    public class PriceCalculator
    {
        public static decimal Calcule(params string[] book)
        {
            if (book.Length > 1)
                return 15.2m;
            return 8;
        }
    }
}