using Frontend.Host.Clients;
using Frontend.Host.Models;

namespace Frontend.Host.Services;

public interface IBookService
{
    Task<IReadOnlyCollection<Book>> GetAllBooks();

    Task<(bool Created, bool Updated, bool Deleted)> SendBatch
    (
        Book? bookToCreate,
        Book? bookToUpdate,
        Book? bookToDelete
    );
}

public class BookService(IBookApiClient client) : IBookService
{
    public async Task<IReadOnlyCollection<Book>> GetAllBooks()
    {
        return (await client.GetBookList()).Select(x => x.ToModel()).ToList();
    }

    public async Task<(bool Created, bool Updated, bool Deleted)> SendBatch
    (
        Book? bookToCreate,
        Book? bookToUpdate,
        Book? bookToDelete
    )
    {
        var requests = new List<BatchOperationRequest?>
        {
            CreateRequest(bookToCreate),
            UpdateRequest(bookToUpdate),
            DeleteRequest(bookToDelete)
        }
            .Where(request => request is not null)
            .ToList();

        var responses = (await client.SendBatch(requests!)).ToList();

        var updatedBook = false;
        var createdBook = false;
        var isDeleted = false;

        for (int i = 0; i < responses.Count; i++)
        {
            var response = responses[i];

            if (requests[i]!.CreateDetails != null && response.Success)
            {
                createdBook = true;
            }
            else if (requests[i]!.ModifyDetails != null && response.Success)
            {
                updatedBook = true;
            }
            else if (requests[i]!.DeleteDetails != null && response.Success)
            {
                isDeleted = true;
            }
        }

        return (createdBook, updatedBook, isDeleted);
    }

    private BatchOperationRequest? CreateRequest(Book? bookToCreate)
    {
        if (bookToCreate == null)
        {
            return null;
        }

        return new BatchOperationRequest(
            CreateDetails: new CreateBookRequest(bookToCreate.Title, bookToCreate.Author, bookToCreate.ReleaseDate),
            null,
            null
        );
    }

    private BatchOperationRequest? UpdateRequest(Book? bookToUpdate)
    {
        if (bookToUpdate == null)
        {
            return null;
        }

        return new BatchOperationRequest(
            null,
            new ModifyBookRequest(bookToUpdate.Id, bookToUpdate.Title, bookToUpdate.Author, bookToUpdate.ReleaseDate),
            null
        );
    }

    private BatchOperationRequest? DeleteRequest(Book? bookToDelete)
    {
        if (bookToDelete == null)
        {
            return null;
        }

        return new BatchOperationRequest(
            null,
            null,
            new DeleteBookRequest(bookToDelete.Id)
        );
    }
}