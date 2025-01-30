namespace Frontend.Host.Clients;

public record BookResponse
(
    Guid Id,
    string Title,
    string Author,
    DateOnly ReleaseDate
);