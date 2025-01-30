using Api.Host.Application.Commands;
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

    public static BookOperationResponse ToResponse(this BookCommandResult result)
    {
        if (!result.Success)
        {
            return new BookOperationResponse(Success: false, Result: null, ErrorMessage: result.ErrorMessage);
        }
        
        return result switch
        {
            CreateBookCommandResult createResult => createResult.ToResponse(),
            ModifyBookCommandResult modifyResult => modifyResult.ToResponse(),
            DeleteBookCommandResult deleteResult => deleteResult.ToResponse(),
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        };
    }
        

    private static BookOperationResponse ToResponse(this CreateBookCommandResult result) =>
        new(
            Success: result.Success,
            Result: result.Book?.ToResponse()
        );

    private static BookOperationResponse ToResponse(this ModifyBookCommandResult result) =>
        new(
            Success: result.Success,
            Result: result.Book?.ToResponse()
        );
    
    private static BookOperationResponse ToResponse(this DeleteBookCommandResult result) =>
        new(
            Success: result.Success,
            Result: null
        );
}