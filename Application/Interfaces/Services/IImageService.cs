using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IImageService
{
    Task<Result<FileStream>> GetImage(Guid id);
    Task<Result<ImageDto>> Upload(Stream stream);
}