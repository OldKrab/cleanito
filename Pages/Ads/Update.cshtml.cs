using Cleanito.Data;
using Cleanito.Models;
using Cleanito.Pages.Shared;
using Cleanito.Services;
using Cleanito.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cleanito.Pages.Ads;

public class UpdateModel : BaseModel
{
    [BindProperty] public AdViewModel AdVM { get; set; }
    [BindProperty] public List<Service> AllServices { get; }
    [BindProperty] public string ImageName { get; private set; }
    [BindProperty] public bool IsDeletePreviousImage { get;  set; }

    [BindProperty] public int AdId { get; private set; }

    private IWebHostEnvironment WebHostEnvironment { get; }

    public UpdateModel(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
        using CleanitoContext db = new();
        AllServices = db.Services.ToList();
    }

    public IActionResult OnGet(int adId)
    {
        using CleanitoContext db = new();
        var ad = db.Ads.Include(ad=>ad.Services).FirstOrDefault(ad => ad.AdId == adId);
        if (ad == null) return NotFound();
        AdVM = new AdViewModel
        {
            Name = ad.Name,
            Description = ad.Description,
            City = ad.City,
            Price = ad.Price,
            ServicesIds = ad.Services.Select(s=>s.ServiceId).ToList()
        };
        ImageName = ad.ImageName;
        AdId = ad.AdId;
        return Page();
    }

    public IActionResult OnPost(int adId)
    {
        if (!ModelState.IsValid)
            return Page();
        using CleanitoContext db = new();
        var ad = db.Ads.Include(ad=>ad.Services).FirstOrDefault(ad => ad.AdId == adId);
        if (ad == null) return NotFound();
        db.Entry(ad).CurrentValues.SetValues(AdVM);
        ad.Services = db.Services.Where(s => AdVM.ServicesIds.Contains(s.ServiceId)).ToList();
        ad.User = db.Users.Find(CurrentUser.UserId);
        
        if (IsDeletePreviousImage)
        {
            ImageService.DeleteImage(ad.ImageName, WebHostEnvironment.WebRootPath);
            ad.ImageName = "";
        }

        if (AdVM.Image != null)
        {
            ImageService.DeleteImage(ad.ImageName, WebHostEnvironment.WebRootPath);
            ad.ImageName = ImageService.SaveImage(AdVM.Image, WebHostEnvironment.WebRootPath);
        }

        db.SaveChanges();
        return RedirectToPage("/UserAds");
    }
}