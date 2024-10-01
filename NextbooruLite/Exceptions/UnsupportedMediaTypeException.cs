using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public class UnsupportedMediaTypeException : HttpException
{
    public UnsupportedMediaTypeException(string type)
        : base(StatusCodes.Status400BadRequest, $"Format {type} is not supported.")
    {
    }

    public override ProblemDetails ToProblemDetails()
    {
        var pd = base.ToProblemDetails();
        pd.Type = $"/errors/core/{GetType().Name}";
        return pd;
    }
}