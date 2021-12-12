namespace PotterKata
{
    public class ShoppingCart
    {
        public ShoppingCart(params string[] books)
        {
            Books = books;
        }

        public string[] Books { get; }
    }
}