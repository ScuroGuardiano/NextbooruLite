using Microsoft.Extensions.Options;
using NextbooruLite.Configuration;

namespace NextbooruLite.Services;

public class LocalMediaStore : IMediaStore
{
    private readonly NextbooruOptions _options;

    public LocalMediaStore(IOptions<NextbooruOptions> options)
    {
        _options = options.Value;
    }
    
    public async Task<string> SaveFile(Stream fileStream, string extension)
    {
        await using var outStream = await OpenWriteStream(extension, out var randomName);
        await fileStream.CopyToAsync(outStream);

        return randomName;
    }

    public Task<Stream> OpenWriteStream(string extension, out string storeFileId)
    {
        var randomName = Path.GetRandomFileName().Replace(".", "") + extension;

        if (!Directory.Exists(_options.MediaStoragePath))
        {
            Directory.CreateDirectory(_options.MediaStoragePath);
        }
        
        storeFileId = randomName;
        return Task.FromResult<Stream>(File.Open(Path.Join(_options.MediaStoragePath, randomName), FileMode.CreateNew));
    }

    public Task<Stream> ReadFile(string id)
    {
        return Task.FromResult<Stream>(File.OpenRead(Path.Join(_options.MediaStoragePath, id)));
    }
}