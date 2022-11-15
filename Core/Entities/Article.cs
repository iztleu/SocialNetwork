namespace Core.Entities;

public class Article
{
    public Article(string title, string description, string body)
    {
        Title = title;
        Description = description;
        Body = body;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
    
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    public string Body { get; set; }
    
    public long AuthorId { get; set; } 
    
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}