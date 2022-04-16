using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cleanito.ViewModel;

public class AdViewModel
{
    [Required]
    [DisplayName("Имя")]
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0, 10000)]
    [DisplayName("Цена")]
    public int? Price { get; set; }
    public string City { get; set; }
    public List<int> ServicesIds { get; set; } = new();
    public IFormFile Image { get; set; }
}