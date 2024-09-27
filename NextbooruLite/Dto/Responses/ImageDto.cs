using NextbooruLite.Dto.Responses;
using NextbooruLite.Model;

namespace NextbooruLite.Dto.General;

public class ImageDto
{
    public required long Id { get; init; }
    public required string Url { get; init; }
    public string? ThumbnailUrl { get; init; }
    public string? PreviewUrl { get; init; }
    public string? Title { get; init; }
    public string? Source { get; init; }
    public string? ContentType { get; init; }
    public string? Extension { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public long SizeInBytes { get; init; }
    public required bool IsPublic { get; init; }
    public BasicUserInfo? UploadedBy { get; init; }
    public List<TagDto> Tags { get; init; } = [];
}