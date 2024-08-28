using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class ImageInvalidError(Guid imageId) :
    ErrorBase(StatusCodes.Status400BadRequest, $"Image {imageId} does not exist");