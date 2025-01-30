using System.ComponentModel.DataAnnotations;

namespace Frontend.Host.Models;

public class Book
{
    public Book(Guid id, string title, string author, DateOnly releaseDate)
    {
        Id = id;
        Title = title;
        Author = author;
        ReleaseDate = releaseDate;
    }

    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Author is required.")]
    public string Author { get; set; }
    public DateOnly ReleaseDate { get; set; }
}