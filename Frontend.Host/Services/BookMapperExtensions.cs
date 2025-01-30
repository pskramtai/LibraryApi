using Frontend.Host.Clients;
using Frontend.Host.Models;

namespace Frontend.Host.Services;

public static class BookMapperExtensions
{
    public static Book ToModel(this BookResponse response) =>
        new(
            id: response.Id,
            title: response.Title,
            author: response.Author,
            releaseDate: response.ReleaseDate
        );
}