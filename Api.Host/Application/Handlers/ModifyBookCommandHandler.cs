using Api.Host.Application.Commands;
using Api.Host.Application.Mappers;
using Api.Host.Domain.Repositories;

namespace Api.Host.Application.Handlers;

public class ModifyBookCommandHandler(IBookRepository bookRepository) : BaseBookCommandHandler<ModifyBookCommand, BookCommandResult>
{
    protected override async Task<BookCommandResult> PerformOperationAsync(ModifyBookCommand command)
    {
        var book = command.ToDomain();
        
        var result = await bookRepository.ModifyBook(book);
            
        return new ModifyBookCommandResult(true, result);
    }
}