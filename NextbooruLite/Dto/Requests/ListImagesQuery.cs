using System.Runtime.Serialization;
using FluentValidation;

namespace NextbooruLite.Dto.Requests;

public class ListImagesQuery : PaginatedListQuery
{
    public string? Tags { get; set; }

    // I will get read of that after implementing SearchParser
    [IgnoreDataMember]
    public string[] TagsArray => string.IsNullOrEmpty(Tags) ? Array.Empty<string>() : Tags.Split(Comma);

    private const string Comma = ",";

    public class ListImagesQueryValidator : AbstractValidator<ListImagesQuery>
    {
        public ListImagesQueryValidator()
        {
            Include(new PaginatedListQueryValidator());
        }
    }
}