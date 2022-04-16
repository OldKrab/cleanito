using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Microsoft.EntityFrameworkCore;

namespace Cleanito.Pages;

public class UserAdsModel : BaseModel
{
    public IEnumerable<Ad> UserAds { get; private set; }

    public void OnGet()
    {
        CleanitoContext db = new();
        db.Attach(CurrentUser)
            .Collection(u => u.Ads)
            .Query()
            .Include(ad => ad.Services)
            .Load();
        UserAds = CurrentUser.Ads.OrderByDescending(ad=>ad.CreationDate);
    }
}