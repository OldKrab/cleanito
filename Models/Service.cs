namespace Cleanito.Models;

public class Service
{
    public int ServiceId { get; set; }
    public string Name { get; set; }
    
    public HashSet<Ad> Ads { get; set; } = new();

}