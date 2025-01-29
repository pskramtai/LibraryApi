using Api.Host.Domain.Models;
using Api.Host.Presentation.Responses;

namespace Api.Host.Presentation.Mappers;

public static class ResponseMapperExtensions
{
    public static BookResponse ToResponse(this Book book) =>
        new(
            Id: book.Id,
            Title: book.Title,
            Author: book.Author,
            ReleaseDate: book.ReleaseDate
        );
}