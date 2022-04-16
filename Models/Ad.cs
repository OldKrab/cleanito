namespace Cleanito.Models;

public class Ad
{
    public int AdId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now.ToUniversalTime();
    public int Price { get; set; }
    public string City { get; set; }
    public string ImageName { get; set; }
    
    public User User { get; set; }

    public ICollection<Service> Services { get; set; } = new HashSet<Service>();
}