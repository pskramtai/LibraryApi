using Api.Host.Application.Dto;
using Api.Host.Application.Services;
using Api.Host.Domain.Exceptions;
using Api.Host.Presentation.Filters;
using Api.Host.Presentation.Mappers;
using Api.Host.Presentation.Requests;
using Api.Host.Presentation.Responses;

namespace Api.Host.Presentation.Endpoints;

public static class BookBatchProcessing
{
    public static WebApplication RegisterBookBatchProcessingEndpoint(this WebApplication app)
    {
        app
            .MapPost("/books/batch", Handler)
            .AddEndpointFilter<ValidationFilter<IReadOnlyCollection<BatchOperationRequest>>>();

        return app;
    }

    private static async Task<IResult> Handler(IBookBatchService service, IReadOnlyCollection<BatchOperationRequest> request)
    {
        var commands = request.Select(x => x.ToCommand()).ToList();

        try
        {
            var results = await service.ExecuteBatchAsync(new BatchOperationDetails(commands));

            return Results.Ok(new BatchOperationResponse(results));
        }
        catch (ConflictingOperationsException e)
        {
            return Results.Conflict(e.ToResponse());
        }
    }
}