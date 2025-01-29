using Api.Host.Application.Commands;
using Api.Host.Application.Mappers;
using Api.Host.Domain.Repositories;

namespace Api.Host.Application.Handlers;

public class CreateBookCommandHandler(IBookRepository bookRepository) : BaseBookCommandHandler<CreateBookCommand, BookCommandResult>
{
    protected override async Task<BookCommandResult> PerformOperationAsync(CreateBookCommand command)
    {
        var book = command.ToDomain();

        var result = await bookRepository.AddBook(book);
        
        return new CreateBookCommandResult(true, result);
    }
}