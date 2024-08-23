using Application.DTO;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class ImageService(IImageRepository imageRepository) : IImageService
{
    private readonly IImageRepository _imageRepository = imageRepository;
    public async Task<Result<FileStream>> GetImage(Guid id)
    {
        return await _imageRepository.GetFileStream(new Image(id));
    }

    public async Task<Result<ImageDto>> Upload(Stream stream)
    {
        Result<Image> result = await _imageRepository.Upload(stream);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(new ImageDto(result.Value.Guid));
    }
}
