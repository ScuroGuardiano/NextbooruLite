using Microsoft.Extensions.Options;
using NextbooruLite.Configuration;
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
    private readonly NextbooruOptions _options;

    public ImageUrlService(IOptionsSnapshot<NextbooruOptions> options)
    {
        _options = options.Value;
    }
    
    public string GetImageUrl(Image image)
    {
        return $"/api/images/{image.Id}.{image.Extension}";
    }

    public string? GetThumbnailImageUrl(Image image)
    {
        return $"/api/images/{image.Id}/thumbnail.{_options.ThumbnailFormat}";
    }

    public string? GetPreviewImageUrl(Image image)
    {
        return $"/api/images/{image.Id}/preview.{_options.PreviewFormat}";
    }
}