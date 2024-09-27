using System.ComponentModel.DataAnnotations;
using NextbooruLite.Helpers;

namespace NextbooruLite.Model;

public class Tag : BaseEntity
{
    [Orderable]
    public int Id { get; set; }
    
    [Required, Orderable]
    public required string Name { get; set; }

    [Required, Orderable]
    public TagType TagType { get; set; } = TagType.General;
    
    /// <summary>
    /// Just information for an user. It should count only <b>public</b> images.
    /// </summary>
    [Orderable]
    public int ImagesCount { get; set; }

    public ICollection<Image> Images { get; } = [];
}
