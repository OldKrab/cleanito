namespace Cleanito.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public bool IsIndividual { get; set; }
    public string ImageName { get; set; }

    public HashSet<Ad> Ads { get; set; } = new();
}