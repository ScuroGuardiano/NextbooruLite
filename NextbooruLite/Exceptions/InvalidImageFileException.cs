using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public class InvalidImageFileException : HttpException
{
    public InvalidImageFileException(string fileName, string contentType) : base(StatusCodes.Status400BadRequest,
        $"Image file {fileName} is invalid. (content-type: {contentType})") {}

    public override ProblemDetails ToProblemDetails()
    {
        var pd = base.ToProblemDetails();
        pd.Type = $"/error/core/{GetType().Name}";
        return pd;
    }
}