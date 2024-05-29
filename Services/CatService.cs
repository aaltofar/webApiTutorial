using System.ComponentModel;
using webApiTutorial.Models;
using System.Linq;

namespace webApiTutorial.Services;

public static class CatService
{
    static List<Cat> Cats { get; }
    static int nextId = 3;
    static CatService()
    {
        Cats =
        [
            new() {Id = 1, Name = "Oliver", IsCool = true},
            new() {Id = 2, Name = "Fridtjof", IsCool = false}
        ];
    }

    public static List<Cat> GetAll() => Cats;

    public static Cat? Get(int id) => Cats.FirstOrDefault(p => p.Id == id);


    public static void Add(Cat cat)
    {
        cat.Id = nextId++;
        Cats.Add(cat);
    }

    public static void Delete(int id)
    {
        var cat = Get(id);
        if (cat is null)
            return;

        Cats.Remove(cat);
    }

    public static void Update(Cat cat)
    {
        var index = Cats.FindIndex(p => p.Id == cat.Id);

        if (index == -1)
            return;

        Cats[index] = cat;
    }

}