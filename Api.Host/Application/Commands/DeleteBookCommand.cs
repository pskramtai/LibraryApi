namespace Api.Host.Application.Commands;

public record DeleteBookCommand
(
    Guid Id
) : IBookCommand<DeleteBookBookCommandResult>;

public record DeleteBookBookCommandResult(
    bool Success
) : BookCommandResult(Success);
