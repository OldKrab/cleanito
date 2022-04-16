using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Cleanito.Services;
using Cleanito.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cleanito.Pages.Ads;

public class CreateModel : BaseModel
{
    [BindProperty] public AdViewModel AdVM { get; set; }

    public List<Service> AllServices { get; set; }

    private IWebHostEnvironment WebHostEnvironment { get; }

    public CreateModel(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
        using CleanitoContext db = new();
        AllServices = db.Services.ToList();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        using CleanitoContext db = new();
        var entry = db.Add(new Ad());
        entry.CurrentValues.SetValues(AdVM);
        entry.Entity.Services = AdVM.ServicesIds.Select(s => db.Services.Find(s)).ToHashSet();
        entry.Entity.User = db.Users.Find(CurrentUser.UserId);
        if (AdVM.Image != null)
            entry.Entity.ImageName = ImageService.SaveImage(AdVM.Image, WebHostEnvironment.WebRootPath);
        db.SaveChanges();
        return RedirectToPage("/UserAds");
    }
}