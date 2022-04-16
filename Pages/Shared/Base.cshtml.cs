using Cleanito.Data;
using Cleanito.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cleanito.Pages.Shared;

public class BaseModel : PageModel
{
    public User CurrentUser { get; set; }

    public BaseModel()
    {
        using CleanitoContext db = new();
        CurrentUser = db.Users.Find(2) ?? db.Users.First();
        CurrentUser.ImageName = "test.png";
        db.SaveChanges();
    }
}

