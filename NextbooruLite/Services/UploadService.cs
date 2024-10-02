using Microsoft.Extensions.Options;
using MimeTypes;
using NextbooruLite.Auth.Model;
using NextbooruLite.Configuration;
using NextbooruLite.Dto.Requests;
using NextbooruLite.Exceptions;
using NextbooruLite.Model;
using SixLabors.ImageSharp;
using Image = NextbooruLite.Model.Image;
using ImageSharpImage = SixLabors.ImageSharp.Image;

namespace NextbooruLite.Services;

public interface IUploadService
{
    public Task<Image> UploadImage(UploadFileFormData request, User user);
}

public class UploadService : IUploadService
{
    private readonly AppDbContext _dbContext;
    private readonly IImageConvertionService _imageConvertionService;
    private readonly ITagService _tagService;
    private readonly IMediaStore _mediaStore;
    private readonly NextbooruOptions _options;
    private readonly ILogger<UploadService> _logger;

    public UploadService(ITagService tagService, IImageConvertionService imageConvertionService, AppDbContext dbContext,
        IMediaStore mediaStore, IOptionsSnapshot<NextbooruOptions> options, ILogger<UploadService> logger)
    {
        _dbContext = dbContext;
        _mediaStore = mediaStore;
        _logger = logger;
        _imageConvertionService = imageConvertionService;
        _tagService = tagService;
        _options = options.Value;
    }

    public async Task<Image> UploadImage(UploadFileFormData request, User user)
    {
        var extension = MimeTypeMap.GetExtension(request.File.ContentType, false);

        if (!_options.AllowedUploadExtensions.Contains(extension))
        {
            throw new NotAllowedFileTypeException(extension, request.File.ContentType);
        }

        var size = request.File.Length;
        
        _logger.LogDebug("Uploading file {FileName} with size {Size} and extension {Extension}...", request.File.FileName, size, extension);

        _logger.LogDebug("Loading image with SixLabors.ImageSharp...");
        using var rawImage = await LoadImageAsync(request);
        _logger.LogDebug("Loaded the image. Dims: {Width}x{Height}", rawImage.Width, rawImage.Height);
        
        int width = rawImage.Width;
        int height = rawImage.Height;
        
        await using var fileStream = request.File.OpenReadStream();
        
        _logger.LogDebug("Saving image to store {MediaStoreType}", _mediaStore.GetType().FullName);
        var storeFileId = await _mediaStore.SaveFile(fileStream, extension);
        _logger.LogDebug("Saved image to the store {MediaStoreType}, storeFileId {StoreFileId}", _mediaStore.GetType().FullName, storeFileId);
        
        var tags = await _tagService.GetOrAddTagsFromString(request.Tags);
        foreach (var tag in tags)
        {
            tag.ImagesCount++;
        }

        var image = new Image()
        {
            StoreFileId = storeFileId,
            Title = request.Title,
            Source = request.Source,
            ContentType = request.File.ContentType,
            Extension = extension,
            UploadedBy = user,
            Width = width,
            Height = height,
            SizeInBytes = size,
            Tags = tags,
            TagsArr = tags.Select(t => t.Id).ToList()
        };

        if (request.Public)
        {
            image.IsPublic = true;
            image.PublishedAt = DateTime.UtcNow;
        }
        
        var thumbnail = await GenerateThumbnail(rawImage);
        var preview = await GeneratePreview(rawImage);
        
        image.Variants = [thumbnail, preview];
        
        _logger.LogDebug("Saving image to the database...");
        _dbContext.Add(image);
        await _dbContext.SaveChangesAsync();
        _logger.LogDebug("Saved image to the database.");

        return image;
    }

    private async Task<ImageSharpImage> LoadImageAsync(UploadFileFormData request)
    {
        try
        {
            await using var stream = request.File.OpenReadStream();
            return await ImageSharpImage.LoadAsync(stream);
        }
        catch (InvalidImageContentException exception)
        {
            _logger.LogError(exception, "File {FileName} (Content-Type: {ContentType}) has invalid content.",
                request.File.FileName, request.File.ContentType);
            
            throw new InvalidImageFileException(request.File.FileName, request.File.ContentType);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Load of image {FileName} (Content-Type: {ContentType}) has failed.", request.File.FileName, request.File.ContentType);
            throw;
        }
    }

    private async Task<ImageVariant> GenerateThumbnail(ImageSharpImage image)
    {
        _logger.LogDebug("Generating thumbnail for an image...");
        var format = _options.ThumbnailFormat;
        var targetWidth = _options.ThumbnailWidth;
        var targetQuality = _options.ThumbnailQuality;
        
        await using var stream = await _mediaStore.OpenWriteStream($".{format}", out var storeFileId);
        _logger.LogDebug("Converting and streaming thumbnail to store {_mediaStore}", _mediaStore.GetType().FullName);
        var convertionResult = await _imageConvertionService.ConvertImage(image, stream, new ImageConvertionOptions()
        {
            Format = format,
            Quality = targetQuality,
            Width = targetWidth,
        });
        _logger.LogDebug("Conversion finished, convertionResult: {@ConvertionResult}, storeFileId: {StoreFileId}", convertionResult, storeFileId);

        var variant = new ImageVariant()
        {
            StoreFileId = storeFileId,
            Width = convertionResult.Width,
            Height = convertionResult.Height,
            Extension = $".{format}",
            ContentType = MimeTypeMap.GetMimeType($".{format}"),
            SizeInBytes = stream.Length,
            VariantMode = VariantMode.Thumbnail
        };

        return variant;
    }

    private async Task<ImageVariant> GeneratePreview(ImageSharpImage image)
    {
        _logger.LogDebug("Generating preview for an image...");
        var format = _options.PreviewFormat;
        var targetWidth = _options.PreviewWidth;
        var targetQuality = _options.PreviewQuality;
        
        await using var stream = await _mediaStore.OpenWriteStream($".{format}", out var storeFileId);
        _logger.LogDebug("Converting and streaming preview to store {_mediaStore}", _mediaStore.GetType().FullName);
        
        var convertionResult = await _imageConvertionService.ConvertImage(image, stream, new ImageConvertionOptions()
        {
            Format = format,
            Quality = targetQuality,
            Width = targetWidth,
        });
        _logger.LogDebug("Conversion finished, convertionResult: {@ConvertionResult}, storeFileId: {StoreFileId}", convertionResult, storeFileId);

        var variant = new ImageVariant()
        {
            StoreFileId = storeFileId,
            Width = convertionResult.Width,
            Height = convertionResult.Height,
            Extension = $".{format}",
            ContentType = MimeTypeMap.GetMimeType($".{format}"),
            SizeInBytes = stream.Length,
            VariantMode = VariantMode.Preview
        };

        return variant;
    }
}