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
    
    /// <summary>
    /// This method breaks abstraction but for now I don't care. I may fix that later.
    /// FIXME: This interface should be independent just like Unites States after declaring independence.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public Task<ConvertionResult> ConvertImage(SixLaborsImage input, Stream output, ImageConvertionOptions options);
}