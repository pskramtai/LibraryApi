using Api.Host.Application.Commands;
using Api.Host.Presentation.Requests;

namespace Api.Host.Presentation.Mappers;

public static class RequestMapperExtensions
{
    public static IBookCommand<BookCommandResult> ToCommand(this BookOperationRequest request)
    {
        return request switch
        {
            { CreateDetails: not null } => request.CreateDetails.ToCommand(),
            { DeleteDetails: not null } => request.DeleteDetails.ToCommand(),
            { ModifyDetails: not null} => request.ModifyDetails.ToCommand(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static CreateBookCommand ToCommand(this CreateBookRequest request) =>
        new(
            Title: request.Title,
            Author: request.Author,
            ReleaseDate: request.ReleaseDate!.Value
        );
    
    private static DeleteBookCommand ToCommand(this DeleteBookRequest request) =>
        new(
            Id: request.Id!.Value
        );

    private static ModifyBookCommand ToCommand(this ModifyBookRequest request) =>
        new(
            Id: request.Id!.Value,
            Title: request.Title,
            Author: request.Author,
            ReleaseDate: request.ReleaseDate!.Value
        );
}