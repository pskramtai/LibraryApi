using Api.Host.Domain.Services;
using Api.Host.Presentation.Mappers;
using Api.Host.Presentation.Responses;

namespace Api.Host.Presentation.Endpoints;

public static class GetBookListEndpoint
{
    public static WebApplication RegisterGetBookListEndpoint(this WebApplication app)
    {
        app
            .MapGet("/books/", Handler)
            .RequireAuthorization();

        return app;
    }

    private static async Task<IReadOnlyCollection<BookResponse>> Handler(IBookService service) => 
        (await service.GetAllBooks()).Select(x => x.ToResponse()).ToList();
}