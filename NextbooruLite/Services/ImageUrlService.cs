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

// This service will be rebuild but later XD
public class ImageUrlService : IImageUrlService
{
    public string GetImageUrl(Image image)
    {
        return $"/api/images/{image.Id}{image.Extension}";
    }

    public string? GetThumbnailImageUrl(Image image)
    {
        var thumbnailVariant = image.Variants.FirstOrDefault(v => v.VariantMode == VariantMode.Thumbnail);
        return thumbnailVariant is not null ? $"/api/images/{image.Id}/thumbnail{thumbnailVariant.Extension}" : null;
    }

    public string? GetPreviewImageUrl(Image image)
    {
        var previewVariant = image.Variants.FirstOrDefault(v => v.VariantMode == VariantMode.Preview);
        return previewVariant is not null ? $"/api/images/{image.Id}/preview{previewVariant.Extension}" : null;
    }
}