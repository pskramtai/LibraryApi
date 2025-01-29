namespace Api.Host.Application.Commands;

public record DeleteBookCommand
(
    Guid Id
) : IBookCommand<DeleteBookCommandResult>;

public record DeleteBookCommandResult(
    bool Success
) : BookCommandResult(Success);
