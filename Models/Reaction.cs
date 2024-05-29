namespace webApiTutorial.Models;

public class Reaction
{
    public Guid Id { get; set; }
    public string? ReactionType { get; set; }

    public Reaction()
    {
        Id = Guid.NewGuid();
    }
}