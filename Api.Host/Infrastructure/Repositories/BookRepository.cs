using Api.Host.Domain.Models;
using Api.Host.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Host.Infrastructure.Repositories;

public class BookRepository(IDbContextFactory<BookDbContext> contextFactory) : IBookRepository
{
    public async Task<IReadOnlyCollection<Book>> GetAllBooks()
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        return await context.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book> AddBook(Book book)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        
        return book;
    }

    public async Task<Book> ModifyBook(Book book)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        
        var existingBook = await context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == book.Id);

        if (existingBook is null)
        {
            throw new KeyNotFoundException($"Book with id: {book.Id} was not found");
        }
        
        context.Books.Update(book);
        await context.SaveChangesAsync();

        return book;
    }

    public async Task DeleteBook(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        
        var existingBook = await context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (existingBook is null)
        {
            throw new KeyNotFoundException($"Book with id: {id} was not found");
        }
        
        context.Books.Remove(existingBook);
        
        await context.SaveChangesAsync(); 
    }
}