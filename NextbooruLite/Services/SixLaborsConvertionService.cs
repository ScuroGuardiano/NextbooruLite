using NextbooruLite.Exceptions;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace NextbooruLite.Services;

public class SixLaborsConvertionService : IImageConvertionService
{
    public async Task<ConvertionResult> ConvertImage(Stream input, Stream output, ImageConvertionOptions options)
    {
        using var image = await SixLaborsImage.LoadAsync(input);
        return await ConvertImage(image, output, options);
    }

    public async Task<ConvertionResult> ConvertImage(SixLaborsImage input, Stream output, ImageConvertionOptions options)
    {
        var resultImage = input;

        try
        {
            if (options.Width != 0 && options.Width < input.Width)
            {
                resultImage = input.Clone(x => x.Resize(options.Width, 0));
            }

            ImageEncoder encoder;
            var quality = 0;

            switch (options.Format)
            {
                case "jpg":
                case "jpeg":
                    if (options.Quality > 0)
                    {
                        encoder = new JpegEncoder()
                        {
                            Quality = options.Quality
                        };
                        quality = options.Quality;
                    }
                    else
                    {
                        encoder = new JpegEncoder();
                    }
                    break;

                case "webp":
                    if (options.Quality > 0)
                    {
                        encoder = new WebpEncoder()
                        {
                            Quality = options.Quality
                        };
                        quality = options.Quality;
                    }
                    else
                    {
                        encoder = new WebpEncoder();
                    }
                    break;

                case "png":
                    encoder = new PngEncoder();
                    break;

                case "gif":
                    encoder = new GifEncoder();
                    break;

                default:
                    throw new UnsupportedMediaTypeException(options.Format);
            }

            await resultImage.SaveAsync(output, encoder);
            return new ConvertionResult()
            {
                Format = options.Format,
                Width = resultImage.Width,
                Height = resultImage.Height,
                Quality = quality
            };
        }
        finally
        {
            if (resultImage != input)
            {
                resultImage.Dispose();
            }
        }
    }
}