namespace NextbooruLite.Dto.Responses;

public class ListResponse<T>
{
    public required ICollection<T> Data { get; init; }
    public int Page { get; init; }
    public int TotalPages { get; init; }
    public int TotalRecords { get; init; }
    public int RecordsPerPage { get; init; }
}