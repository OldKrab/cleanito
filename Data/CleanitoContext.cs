using Cleanito.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleanito.Data;

public class CleanitoContext : DbContext
{
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Host=192.168.100.228;Database=cleanito;Username=postgres;Password=123;SearchPath=aspnet;");
}