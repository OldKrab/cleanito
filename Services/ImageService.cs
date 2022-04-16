namespace Cleanito.Services;

public static class ImageService
{
    public static string SaveImage(IFormFile image, string webRootPath)
    {
        var newFileName = Guid.NewGuid() + "_" + image.FileName;
        var file = Path.Combine(webRootPath, "images", newFileName);
        using var fileStream = new FileStream(file, FileMode.Create);
        image.CopyTo(fileStream);
        return newFileName;
    }

    public static void DeleteImage(string imageName, string webRootPath)
    {
        var image = Path.Combine(webRootPath, "images", imageName);
        if (File.Exists(image))
            File.Delete(image);
    }
}