namespace Api.Host.Presentation.Requests;

public record CreateBookRequest(
    string Title,
    string Author,
    DateOnly? ReleaseDate
);