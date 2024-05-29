using System.ComponentModel;
using webApiTutorial.Models;
using System.Linq;

namespace webApiTutorial.Services;

public static class UserService
{
    static List<User> Users { get; }
    static UserService()
    {
        Users =
        [
            new("Ludde", "https://th.bing.com/th/id/OIP.2j8K1EcDhB1tFpEL6CXrxAHaJ4?rs=1&pid=ImgDetMain", "52639b52-1bb3-4f9b-8675-ed4f3f3a80ee"),
            new("Glenn", "https://th.bing.com/th/id/R.7b728691017ba073285877808c17728c?rik=TAUnpFgTzsQ0JQ&riu=http%3a%2f%2fd.ibtimes.co.uk%2fen%2ffull%2f405457%2fwhy-he-did-it-not-clear-some-say-it-was-because-bapus-arrest-some-say-it-was-because-he.jpg&ehk=z7oGgvnwXIChAAwa4m4OM96hCXYSAwnhnmz8C1Qd4us%3d&risl=&pid=ImgRaw&r=0", "368b5da9-fa7d-4cbc-a887-cfcfea06f572"),
        ];
    }

    public static List<User> GetAll() => Users;

    public static User? Get(Guid id) => Users.FirstOrDefault(u => u.Id == id);


    public static void Add(User user)
    {
        Users.Add(user);
    }

    public static void Delete(Guid id)
    {
        var user = Get(id);
        if (user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);

        if (index == -1)
            return;

        Users[index] = user;
    }

}