using Api.Host.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Host.Infrastructure;

public class BookDbContext(DbContextOptions<BookDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.ReleaseDate)
            .HasColumnType("DATE");
    }
}