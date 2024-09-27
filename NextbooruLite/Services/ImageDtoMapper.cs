using NextbooruLite.Dto.General;
using NextbooruLite.Dto.Responses;
using NextbooruLite.Model;

namespace NextbooruLite.Services;

public interface IImageDtoMapper
{
    public ImageDto ToImageDto(Image image);
}

public class ImageDtoMapper : IImageDtoMapper
{
    private readonly IImageUrlService _imageUrlService;

    public ImageDtoMapper(IImageUrlService imageUrlService)
    {
        _imageUrlService = imageUrlService;
    }

    public ImageDto ToImageDto(Image image)
    {
        return new ImageDto()
        {
            Id = image.Id,
            Url = _imageUrlService.GetImageUrl(image),
            ThumbnailUrl = _imageUrlService.GetThumbnailImageUrl(image),
            PreviewUrl = _imageUrlService.GetPreviewImageUrl(image),
            Title = image.Title,
            Source = image.Source,
            ContentType = image.ContentType,
            Extension = image.Extension,
            Width = image.Width,
            Height = image.Height,
            SizeInBytes = image.SizeInBytes,
            IsPublic = image.IsPublic,
            Tags = image.Tags?.Select(TagDto.FromTagModel).ToList() ?? [],
            UploadedBy = image.UploadedBy is not null ? new BasicUserInfo(image.UploadedBy) : null
        };
    }
}