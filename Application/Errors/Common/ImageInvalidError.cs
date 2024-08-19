using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class ImageInvalidError(Guid imageId) : 
    ErrorBase(StatusCodes.Status400BadRequest, $"Image {imageId} does not exist");