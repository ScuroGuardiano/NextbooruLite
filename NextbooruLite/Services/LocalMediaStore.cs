namespace NextbooruLite.Services;

public class LocalMediaStore : IMediaStore
{
    public Task<string> SaveFile(Stream fileStream, string extension)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> OpenWriteStream(string extension, out string storeFileId)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> ReadFile(string id)
    {
        throw new NotImplementedException();
    }
}