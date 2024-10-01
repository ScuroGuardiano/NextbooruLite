using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextbooruLite.Auth.Policies;
using NextbooruLite.Auth.Services;
using NextbooruLite.Dto.General;
using NextbooruLite.Dto.Requests;
using NextbooruLite.Services;

namespace NextbooruLite.Controllers;

[ApiController]
[Route("upload")]
public class UploadController : ControllerBase
{
    private readonly SessionService _sessionService;
    private readonly IUploadService _uploadService;
    private readonly IImageDtoMapper _imageDtoMapper;
    private readonly IAuthorizationService _authorizationService;

    public UploadController(SessionService sessionService, IUploadService uploadService, IImageDtoMapper imageDtoMapper,
        IAuthorizationService authorizationService)
    {
        _sessionService = sessionService;
        _uploadService = uploadService;
        _imageDtoMapper = imageDtoMapper;
        _authorizationService = authorizationService;
    }

    [Authorize(Policy = PolicyNames.UploadImage)]
    [HttpPost]
    [RequestSizeLimit(100L * 1024 * 1024)]
    public async Task<ImageDto> Upload([FromForm] UploadFileFormData formData)
    {
        var user = _sessionService.GetCurrentSessionFromHttpContext()?.User;
        if (user is null)
        {
            throw new UnreachableException("Session.User is null in authorized request.");
        }

        if (formData.Public)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, formData, PolicyNames.PublishImage);
            formData.Public = authResult.Succeeded;
        }
        
        var image = await _uploadService.UploadImage(formData, user);

        HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        return _imageDtoMapper.ToImageDto(image);
    }
}