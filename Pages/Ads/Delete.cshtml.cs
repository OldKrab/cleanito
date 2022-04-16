using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Cleanito.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cleanito.Pages.Ads;

public class DeleteModel : BaseModel
{
    [BindProperty] public Ad Ad { get; set; }

    private IWebHostEnvironment WebHostEnvironment { get; }

    public DeleteModel(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IActionResult OnGet(int adId)
    {
        using CleanitoContext db = new();
        Ad = db.Ads.FirstOrDefault(ad => ad.AdId == adId);
        return Ad == null ? NotFound() : Page();
    }

    public IActionResult OnPost(int adId)
    {
        using CleanitoContext db = new();
        var ad = db.Ads.FirstOrDefault(ad => ad.AdId == adId);
        if (ad == null)
            return NotFound();
        ImageService.DeleteImage(ad.ImageName, WebHostEnvironment.WebRootPath);
        db.Ads.Remove(ad);
        db.SaveChanges();
        return RedirectToPage("/UserAds");
    }
}