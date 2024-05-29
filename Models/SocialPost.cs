namespace webApiTutorial.Models;

public class SocialPost
{
    public Guid Id { get; set; }
    public string? Poster { get; set; }
    public bool IsPetting { get; set; }
    public List<Reaction>? Reactions { get; set; }
    public bool IsCat { get; set; }
    public DateOnly PostDate { get; set; }
    public string? Content { get; set; }
    public string? Comment { get; set; }

    public SocialPost()
    {
        Id = Guid.NewGuid();
        Reactions = [];
        PostDate = new();
    }
}