using Api.Host.Domain.Models;
using Api.Host.Domain.Repositories;
using Api.Host.Domain.Services;

namespace Api.Host.Application.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IReadOnlyCollection<Book>> GetAllBooks() => 
        await repository.GetAllBooks();
}