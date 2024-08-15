using Application.DTO;
using Application.Interfaces.Services;
using FluentResults;

namespace Application.Services;

public class ImageService : IImageService
{
    public Task<Result<FileStream>> GetImage(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ImageDto>> Upload(Stream stream)
    {
        throw new NotImplementedException();
    }
}
