using Microsoft.EntityFrameworkCore;
using NextbooruLite.Model;

namespace NextbooruLite.Services;

public interface ITagService
{
    /// <summary>
    /// Retrieves or adds new tags from space separated tag name list.
    /// </summary>
    /// <param name="tagsStr"></param>
    /// <returns></returns>
    public Task<List<Tag>> GetOrAddTagsFromString(string tagsStr, bool saveChanges = false);
}

public class TagService : ITagService
{
    private readonly AppDbContext _dbContext;

    public TagService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tag>> GetOrAddTagsFromString(string tagsStr, bool saveChanges = false)
    {
        var rawTags = tagsStr.Split(' ').Select(t => t.ToLowerInvariant());
        
        var tags = await _dbContext.Tags
            .Where(t => rawTags.Contains(t.Name))
            .ToListAsync();

        foreach (var rawTag in rawTags)
        {
            if (!tags.Exists(t => t.Name == rawTag))
            {
                var tag = new Tag { Name = rawTag };
                tags.Add(tag);
                _dbContext.Add(tag);
            }
        }

        if (saveChanges)
        {
            await _dbContext.SaveChangesAsync();
        }

        return tags;
    }
}