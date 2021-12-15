namespace PotterKata;

public class BooksPack
{
    private List<Book> _books = new List<Book>();

    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public bool CanAdd(Book book) => IsNotFull() && !_books.Contains(book);

    public void Add(Book book) => _books.Add(book);

    private bool IsNotFull() => _books.Count < 5;
}