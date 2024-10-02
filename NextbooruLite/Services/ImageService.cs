using System.Security.Claims;
using NextbooruLite.Dto.General;
using NextbooruLite.Dto.Requests;
using NextbooruLite.Dto.Responses;
using NextbooruLite.Model;

namespace NextbooruLite.Services;

public interface IImageService
{
    public Task<ListResponse<ImageDto>> ListImages(ListImagesQuery query, ClaimsPrincipal user);
    public Task<Image> GetImage(long id, ClaimsPrincipal user);
    public Task PublishImage(long id, ClaimsPrincipal user);
    public Task UnpublishImage(long id, ClaimsPrincipal user);
    public Task DeleteImage(long id, ClaimsPrincipal user);
}

public class ImageService : IImageService
{
    public Task<ListResponse<ImageDto>> ListImages(ListImagesQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<ListResponse<ImageDto>> ListImages(ListImagesQuery query, ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetImage(long id, ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task PublishImage(long id, ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task UnpublishImage(long id, ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteImage(long id, ClaimsPrincipal user)
    {
        throw new NotImplementedException();
    }
}