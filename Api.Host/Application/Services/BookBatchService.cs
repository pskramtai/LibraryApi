using Api.Host.Application.Commands;
using Api.Host.Application.Dto;
using MediatR;

namespace Api.Host.Application.Services;

public interface IBookBatchService
{
    Task<IReadOnlyCollection<BookCommandResult>> ExecuteBatchAsync(BatchOperationDetails batch);
}

public class BookBatchService(IMediator mediator, IBatchValidationService batchValidator) : IBookBatchService
{
    public async Task<IReadOnlyCollection<BookCommandResult>> ExecuteBatchAsync(BatchOperationDetails batch)
    {
        batchValidator.EnsureValid(batch);
        
        var tasks = batch.Commands.Select(x => mediator.Send(x));

        return await Task.WhenAll(tasks);
    }
}