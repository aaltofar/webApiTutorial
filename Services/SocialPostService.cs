using System.ComponentModel;
using webApiTutorial.Models;
using System.Linq;

namespace webApiTutorial.Services;

public static class SocialPostService
{
    static List<SocialPost> SocialPosts { get; }
    static SocialPostService()
    {
        SocialPosts =
        [
            new ()
            {
                Poster = "52639b52-1bb3-4f9b-8675-ed4f3f3a80ee",
                IsPetting = true,
                IsCat = true,
                Content = "https://pbs.twimg.com/media/Ft3dOugWYAAB_TU?format=jpg&name=small",
                Comment = "I pet this lil shit"
            },
            new ()
            {
                Poster = "368b5da9-fa7d-4cbc-a887-cfcfea06f572",
                IsPetting = false,
                IsCat = false,
                Content = "https://i.kym-cdn.com/photos/images/newsfeed/002/224/606/005.png",
                Comment = "Look at this long nosed Pinocchio lookin' ass bitch"
            },
        ];
    }

    public static List<SocialPost> GetAll() => SocialPosts;

    public static SocialPost? Get(Guid id) => SocialPosts.FirstOrDefault(s => s.Id == id);

    public static void Add(SocialPost socialPost)
    {
        SocialPosts.Add(socialPost);
    }

    public static void Delete(Guid id)
    {
        var socialPost = Get(id);
        if (socialPost is null)
            return;

        SocialPosts.Remove(socialPost);
    }

    public static void Update(SocialPost socialPost)
    {
        var index = SocialPosts.FindIndex(s => s.Id == socialPost.Id);

        if (index == -1)
            return;

        SocialPosts[index] = socialPost;
    }

}