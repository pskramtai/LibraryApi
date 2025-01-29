namespace Api.Host.Domain.Models;

public record Book
(
    Guid Id,
    string Title,
    string Author,
    DateOnly ReleaseDate
);