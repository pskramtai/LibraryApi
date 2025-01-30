using Frontend.Host.Models;

namespace Frontend.Host.Services;

public class StateContainer
{
    private List<Book> _books = [];

    public List<Book> GetBooks() => _books;
    
    public void SetBooks(List<Book> books) => _books = books;
}