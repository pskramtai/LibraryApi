using Api.Host.Domain.Models;

namespace Api.Host.Domain.Services;

public interface IBookService
{
    Task<IReadOnlyCollection<Book>> GetAllBooks();
}