namespace PotterKata
{
    public class ShoppingCart
    {
        public ShoppingCart(params Book[] books)
        {
            Books = books;
        }

        public IList<Book> Books { get; }
    }
}