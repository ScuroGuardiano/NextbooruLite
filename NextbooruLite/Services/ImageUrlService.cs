using NextbooruLite.Model;

namespace NextbooruLite.Services;

public interface IImageUrlService
{
    public string GetImageUrl(Image image);
    public string? GetThumbnailImageUrl(Image image);
    public string? GetPreviewImageUrl(Image image);
}

public class ImageUrlService : IImageUrlService
{
    public string GetImageUrl(Image image)
    {
        throw new NotImplementedException();
    }

    public string? GetThumbnailImageUrl(Image image)
    {
        throw new NotImplementedException();
    }

    public string? GetPreviewImageUrl(Image image)
    {
        throw new NotImplementedException();
    }
}