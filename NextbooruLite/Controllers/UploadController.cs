using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextbooruLite.Auth.Policies;
using NextbooruLite.Dto.General;
using NextbooruLite.Dto.Requests;
using NextbooruLite.Services;
using NextbooruLite.Swagger;
using Swashbuckle.AspNetCore.Annotations;

namespace NextbooruLite.Controllers;

[ApiController]
[Route("upload")]
[SwaggerTag("Upload endpoints")]
public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;
    private readonly IImageDtoMapper _imageDtoMapper;
    private readonly IAuthorizationService _authorizationService;

    public UploadController(IUploadService uploadService, IImageDtoMapper imageDtoMapper,
        IAuthorizationService authorizationService)
    {
        _uploadService = uploadService;
        _imageDtoMapper = imageDtoMapper;
        _authorizationService = authorizationService;
    }

    [Authorize(Policy = PolicyNames.UploadImage)]
    [HttpPost]
    [RequestSizeLimit(100L * 1024 * 1024)]
    [SwaggerOperation(Summary = "Uploads an image")]
    [SwaggerResponse(200, "Uploaded image", typeof(ImageDto))]
    [SwaggerUnauthorizedResponse]
    [SwaggerForbiddenResponse]
    public async Task<ImageDto> Upload([FromForm] UploadFileFormData formData)
    {
        if (formData.Public)
        {
            var authResult = await _authorizationService.AuthorizeAsync(User, formData, PolicyNames.PublishImage);
            formData.Public = authResult.Succeeded;
        }

        var image = await _uploadService.UploadImage(formData, User);

        HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        return _imageDtoMapper.ToImageDto(image);
    }
}