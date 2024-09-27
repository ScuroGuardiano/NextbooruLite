using NextbooruLite.Model;

namespace NextbooruLite.Services;

public interface ITagService
{
    /// <summary>
    /// Retrieves or adds new tags from space separated tag name list.
    /// </summary>
    /// <param name="tagsStr"></param>
    /// <returns></returns>
    public Task<List<Tag>> GetOrAddTagsFromString(string tagsStr);
}

public class TagService : ITagService
{
    public Task<List<Tag>> GetOrAddTagsFromString(string tagsStr)
    {
        throw new NotImplementedException();
    }
}