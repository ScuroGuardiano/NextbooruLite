using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace NextbooruLite.Services;

public class ImageConvertionOptions
{
    /// <summary>
    /// Can be set to 0 if <see cref="Height">Height</see> is set, width will be set automatically using aspect ratio
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// Can be set to 0 if <see cref="Width">Width</see> is set, height will be set automatically using aspect ratio
    /// </summary>
    public int Height { get; set; }
    
    /// <summary>
    /// Affect only format supporting Quality, like webp or jpeg
    /// </summary>
    public int Quality { get; set; }
    
    public required string Format { get; set; }
}

public class ConvertionResult
{
    public int Width { get; init; }
    public int Height { get; init; }
    public required string Format { get; init; }
    public int Quality { get; init; }
}

public interface IImageConvertionService
{
    public Task<ConvertionResult> ConvertImage(Stream input, Stream output, ImageConvertionOptions options);
    public Task<ConvertionResult> ConvertImage(SixLaborsImage input, Stream output, ImageConvertionOptions options);
}

public class ImageConvertionService : IImageConvertionService
{
    public Task<ConvertionResult> ConvertImage(Stream input, Stream output, ImageConvertionOptions options)
    {
        throw new NotImplementedException();
    }

    public Task<ConvertionResult> ConvertImage(SixLaborsImage input, Stream output, ImageConvertionOptions options)
    {
        throw new NotImplementedException();
    }
}