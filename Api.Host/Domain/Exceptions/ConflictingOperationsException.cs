namespace Api.Host.Domain.Exceptions;

public class ConflictingOperationsException(HashSet<Guid> conflictingIds)
    : Exception($"There are conflicting operations for books: {string.Join(", ", conflictingIds)}");