namespace Frontend.Host.Clients;

public record CreateBookRequest(
    string Title,
    string Author,
    DateOnly? ReleaseDate
);