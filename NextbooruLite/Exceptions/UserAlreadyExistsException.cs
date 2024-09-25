using Microsoft.AspNetCore.Mvc;

namespace NextbooruLite.Exceptions;

public class UserAlreadyExistsException : HttpException
{
    public UserAlreadyExistsException(string username) : base(StatusCodes.Status409Conflict,
        $"User ${username} already exists.")
    {
        Username = username;
    }


    public string Username { get; set; }
    
    public override ProblemDetails ToProblemDetails()
    {
        var pd = base.ToProblemDetails();
        pd.Type = $"/errors/core/{GetType().Name}";
        pd.Instance = $"/users/by-name/{Username}";

        return pd;
    }
}
