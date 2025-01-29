using Api.Host.Application.Commands;
using Api.Host.Application.Dto;
using Api.Host.Domain.Exceptions;

namespace Api.Host.Application.Services;

public interface IBatchValidationService
{
    void EnsureValid(BatchOperationDetails batch);
}

public class BatchValidationService : IBatchValidationService
{
    public void EnsureValid(BatchOperationDetails batch)
    {
        var conflictingBookIds = GetConflictingBookIds(batch);

        if (conflictingBookIds.Any())
        {
            throw new ConflictingOperationsException(conflictingBookIds);
        }
    }

    private HashSet<Guid> GetConflictingBookIds(BatchOperationDetails batch)
    {
        var bookIds = new HashSet<Guid>();
        var conflictingBookIds = new HashSet<Guid>();

        var ids = batch.Commands.Select(x => x switch
            {
                DeleteBookCommand delete => delete.Id,
                ModifyBookCommand modify => modify.Id,
                _ => (Guid?)null
            })
            .Where(x => x.HasValue);

        foreach (var id in ids)
        {
            if (!bookIds.Add(id!.Value))
            {
                conflictingBookIds.Add(id.Value);
            }
        }

        return conflictingBookIds;
    }
}