using Domain.Entities;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IImageRepository
{
    Task<Result<FileStream>> GetFileStream(Image image);
    Task<Result<Image>> Upload(Stream stream);
    Task<Result> ValidateImage(Image image);
}