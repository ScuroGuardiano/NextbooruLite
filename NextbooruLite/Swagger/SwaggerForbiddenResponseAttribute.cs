using Swashbuckle.AspNetCore.Annotations;

namespace NextbooruLite.Swagger;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SwaggerForbiddenResponseAttribute : SwaggerResponseAttribute
{
    public SwaggerForbiddenResponseAttribute() : base(403, "User is not allowed to perform this action.") {}
}