using Api.Host.Domain.Models;

namespace Api.Host.Domain.Repositories;

public interface IBookRepository
{
    Task<IReadOnlyCollection<Book>> GetAllBooks();
    
    Task<Book> AddBook(Book book);

    Task<Book> ModifyBook(Book book);
    
    Task DeleteBook(Guid id);
}