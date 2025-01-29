using Api.Host.Application.Commands;
using Api.Host.Domain.Repositories;

namespace Api.Host.Application.Handlers;

public class DeleteBookCommandHandler(IBookRepository bookRepository) : BaseBookCommandHandler<DeleteBookCommand, BookCommandResult>
{
    protected override async Task<BookCommandResult> PerformOperationAsync(DeleteBookCommand command)
    {
        await bookRepository.DeleteBook(command.Id);

        return new DeleteBookCommandResult(true);
    }
}