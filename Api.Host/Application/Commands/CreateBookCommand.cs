using Api.Host.Domain.Models;

namespace Api.Host.Application.Commands;

public record CreateBookCommand(
    string Title,
    string Author,
    DateOnly ReleaseDate
) : IBookCommand<CreateBookCommandResult>;

public record CreateBookCommandResult
(
    bool Success,
    Book? Book
) : BookCommandResult(Success);