using System.ComponentModel;
using webApiTutorial.Models;
using System.Linq;

namespace webApiTutorial.Services;

public static class ReactionService
{
    static List<Reaction> Reactions { get; }
    static ReactionService()
    {
        Reactions = [];
    }

    public static List<Reaction> GetAll() => Reactions;

    public static Reaction? Get(Guid id) => Reactions.FirstOrDefault(r => r.Id == id);


    public static void Add(Reaction reaction)
    {
        Reactions.Add(reaction);
    }

    public static void Delete(Guid id)
    {
        var reaction = Get(id);
        if (reaction is null)
            return;

        Reactions.Remove(reaction);
    }

    public static void Update(Reaction reaction)
    {
        var index = Reactions.FindIndex(r => r.Id == reaction.Id);

        if (index == -1)
            return;

        Reactions[index] = reaction;
    }

}