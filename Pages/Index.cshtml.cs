using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Microsoft.EntityFrameworkCore;

namespace Cleanito.Pages;

public class IndexModel : BaseModel
{
    public IEnumerable<Ad> Ads { get; set; }

    public void OnGet()
    {
        using CleanitoContext db = new();
        Ads = db.Ads
            .Include(ad => ad.User)
            .Include(ad => ad.Services)
            .OrderByDescending(ad => ad.CreationDate).ToList();
    }
}