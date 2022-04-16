using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cleanito.Pages.Ads;

public class ViewModel : BaseModel
{
    [BindProperty] public Ad Ad { get; private set; }


    public IActionResult OnGet(int adId)
    {
        using CleanitoContext db = new();
        Ad = db.Ads.Include(ad => ad.User)
            .Include(ad => ad.Services)
            .FirstOrDefault(ad => ad.AdId == adId);
        if (Ad == null) return NotFound();
        return Page();
    }
}