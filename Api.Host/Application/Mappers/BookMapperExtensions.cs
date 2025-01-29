using Api.Host.Application.Commands;
using Api.Host.Domain.Models;

namespace Api.Host.Application.Mappers;

public static class BookMapperExtensions
{
    public static Book ToDomain(this CreateBookCommand command) =>
        new(
            Id: Guid.NewGuid(),
            command.Title,
            command.Author,
            command.ReleaseDate
        );
    
    public static Book ToDomain(this ModifyBookCommand command) =>
        new(
            Id: command.Id,
            command.Title,
            command.Author,
            command.ReleaseDate
        );
}