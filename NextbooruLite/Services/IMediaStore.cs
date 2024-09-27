namespace NextbooruLite.Services;

public interface IMediaStore
{
    public Task<string> SaveFile(Stream fileStream, string extension);
    public Task<Stream> OpenWriteStream(string extension, out string storeFileId);
    public Task<Stream> ReadFile(string id);
}