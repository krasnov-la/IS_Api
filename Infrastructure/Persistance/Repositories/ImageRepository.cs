using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    public Task<Result<FileStream>> GetFileStream(Image image)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Image>> Upload(Stream stream)
    {
        throw new NotImplementedException();
    }

    public bool ValidateImage(Guid imageId)
    {
        throw new NotImplementedException();
    }
}