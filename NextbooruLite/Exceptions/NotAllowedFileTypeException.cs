using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public class NotAllowedFileTypeException : HttpException
{
    public NotAllowedFileTypeException(string extension, string contentType)
        : base(StatusCodes.Status400BadRequest, $"File type {extension} (Content-Type: {contentType}) is not allowed.")
    {
    }

    public override ProblemDetails ToProblemDetails()
    {
        var pd = base.ToProblemDetails();
        pd.Type = $"/errors/core/{GetType().Name}";
        return pd;
    }
}
