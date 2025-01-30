using Frontend.Host.Clients;
using Frontend.Host.Models;

namespace Frontend.Host.Services;

public interface IBookService
{
    Task<IReadOnlyCollection<Book>> GetAllBooks();

    Task<(OperationResult Created, OperationResult Updated, OperationResult Deleted)> SendBatch
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

    public async Task<(OperationResult Created, OperationResult Updated, OperationResult Deleted)> SendBatch
    (
        Book? bookToCreate,
        Book? bookToUpdate,
        Book? bookToDelete
    )
    {
        var requests = new List<BookOperationRequest?>
        {
            CreateRequest(bookToCreate),
            UpdateRequest(bookToUpdate),
            DeleteRequest(bookToDelete)
        }
            .Where(request => request is not null)
            .ToList();

        var responses = (await client.SendBatch(requests!)).ToList();

        OperationResult updatedResult = null!;
        OperationResult createdResult = null!;
        OperationResult deletedResult = null!;

        for (int i = 0; i < responses.Count; i++)
        {
            var response = responses[i];

            if (requests[i]!.CreateDetails is not null)
            {
                createdResult = new OperationResult(response.Success, response.ErrorMessage);
            }
            else if (requests[i]!.ModifyDetails is not null)
            {
                updatedResult =  new OperationResult(response.Success, response.ErrorMessage);
            }
            else if (requests[i]!.DeleteDetails is not null)
            {
                deletedResult = new OperationResult(response.Success, response.ErrorMessage);
            }
        }

        return (createdResult, updatedResult, deletedResult);
    }

    private BookOperationRequest? CreateRequest(Book? bookToCreate)
    {
        if (bookToCreate == null)
        {
            return null;
        }

        return new BookOperationRequest(
            CreateDetails: new CreateBookRequest(bookToCreate.Title, bookToCreate.Author, bookToCreate.ReleaseDate),
            null,
            null
        );
    }

    private BookOperationRequest? UpdateRequest(Book? bookToUpdate)
    {
        if (bookToUpdate == null)
        {
            return null;
        }

        return new BookOperationRequest(
            null,
            new ModifyBookRequest(bookToUpdate.Id, bookToUpdate.Title, bookToUpdate.Author, bookToUpdate.ReleaseDate),
            null
        );
    }

    private BookOperationRequest? DeleteRequest(Book? bookToDelete)
    {
        if (bookToDelete == null)
        {
            return null;
        }

        return new BookOperationRequest(
            null,
            null,
            new DeleteBookRequest(bookToDelete.Id)
        );
    }
}