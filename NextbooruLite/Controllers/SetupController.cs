using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextbooruLite.Auth.Dto;
using NextbooruLite.Auth.Services;
using NextbooruLite.Dto;
using NextbooruLite.Dto.Responses;
using NextbooruLite.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace NextbooruLite.Controllers;

[ApiController]
[AllowAnonymous]
[Route("setup")]
[SwaggerTag("Endpoints related to initial app setup")]
public class SetupController : ControllerBase
{
    private readonly UserService _userService;

    public SetupController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("initialized")]
    [SwaggerOperation(Summary = "Returns whether the initial admin user has been set up or not")]
    [SwaggerResponse(200, "An object indicating if the initial app has been set up", typeof(InitializedResponse))]
    public async Task<InitializedResponse> GetInitialized()
    {
        var initialUser = await _userService.GetInitialUser();
        var initialized = initialUser is not null;
        return new InitializedResponse
        {
            Initialized = initialized
        };
    }
    
    [HttpPost("initial-user")]
    [SwaggerOperation(Summary = "Creates initial admin user if it doesn't exists")]
    [SwaggerResponse(204, "Initial admin user has been created successfully")]
    [SwaggerBadRequestResponse] 
    [SwaggerResponse(409, "Initial admin user already exists.")]
    public async Task<ActionResult> CreateInitialUser([FromBody] CreateInitialUserRequest request)
    {
        await _userService.CreateInitialUser(request.Username, request.Password);
        return NoContent();
    }
}
