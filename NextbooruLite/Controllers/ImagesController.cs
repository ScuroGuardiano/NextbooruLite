using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NextbooruLite.Auth.Policies;
using NextbooruLite.Configuration;
using NextbooruLite.Dto.General;
using NextbooruLite.Dto.Requests;
using NextbooruLite.Dto.Responses;
using NextbooruLite.Model;
using NextbooruLite.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NextbooruLite.Controllers;

[ApiController]
[Route("images")]
[SwaggerTag("Images retrieval, modification and deletion")]
public class ImagesController : ControllerBase
{
    private readonly NextbooruOptions _options;
    private readonly IAuthorizationService _authorizationService;
    private readonly IImageService _imageService;

    public ImagesController(IOptionsSnapshot<NextbooruOptions> options, IAuthorizationService authorizationService, IImageService imageService)
    {
        _authorizationService = authorizationService;
        _imageService = imageService;
        _options = options.Value;
    }

    [HttpGet("detailed")]
    [SwaggerResponse(200,
        "Returns list of images with all details about them. Avoid using this endpoint as it transfers a lot of data",
        typeof(ListResponse<Image>))]
    public async Task<ListResponse<ImageDto>> ListDetailedImages([FromQuery] ListImagesQuery query)
    {
        if (query.ResultsOnPage == 0)
        {
            query.ResultsOnPage = _options.DefaultResultsPerPage;
        }

        if (query.ResultsOnPage > _options.MaxResultsPerPage)
        {
            var authRes = await _authorizationService.AuthorizeAsync(User, PolicyNames.Admin);
            if (!authRes.Succeeded)
            {
                query.ResultsOnPage = _options.MaxResultsPerPage;
            }
        }

        return await _imageService.ListImages(query, User);
    }
}