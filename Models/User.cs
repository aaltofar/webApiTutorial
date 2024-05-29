namespace webApiTutorial.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<string>? Following { get; set; }
    public int Points { get; set; }
    public int PetCount { get; set; }
    public string? ProfilePic { get; set; }

    public User(string name, string pp, string id)
    {
        Id = new Guid(id);
        Points = 0;
        Following = [];
        PetCount = 0;
        Name = name;
        ProfilePic = pp;
    }
}