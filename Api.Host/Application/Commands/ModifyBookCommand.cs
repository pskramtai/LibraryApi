using Api.Host.Domain.Models;

namespace Api.Host.Application.Commands;

public record ModifyBookCommand
(
    Guid Id,
    string Title,
    string Author,
    DateOnly ReleaseDate
) : IBookCommand<ModifyBookCommandResult>;

public record ModifyBookCommandResult
(
    bool Success,
    Book? Book
) : BookCommandResult(Success);