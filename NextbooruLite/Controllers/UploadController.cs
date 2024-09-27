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

    public UploadController(SessionService sessionService, IUploadService uploadService, IImageDtoMapper imageDtoMapper)
    {
        _sessionService = sessionService;
        _uploadService = uploadService;
        _imageDtoMapper = imageDtoMapper;
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

        var image = await _uploadService.UploadImage(formData, user);

        HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        return _imageDtoMapper.ToImageDto(image);
    }
}