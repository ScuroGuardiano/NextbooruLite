using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public interface IConvertibleToProblemDetails
{
    ProblemDetails ToProblemDetails();
}
