using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public class InitialUserAlreadyCreatedException : HttpException
{
    public InitialUserAlreadyCreatedException() : base(StatusCodes.Status409Conflict, "Initial user has been already created") {}

    public override ProblemDetails ToProblemDetails()
    {
        var pd = base.ToProblemDetails();
        pd.Type = $"/errors/core/{GetType().Name}";
        return pd;
    }
}
