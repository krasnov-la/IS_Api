using Application.Errors;
using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Persistance.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly string _imagesPath;
    public ImageRepository(IWebHostEnvironment hostEnvironment)
    {
        _imagesPath = Path.Combine(hostEnvironment.ContentRootPath, "images");
        if (!Directory.Exists(_imagesPath)) Directory.CreateDirectory(_imagesPath);
    }
    public Task<Result<FileStream>> GetFileStream(Image image)
    {
        try 
        {
            var file = new FileStream(Path.Combine(_imagesPath, image.Guid.ToString()), FileMode.Open);
            return Task.FromResult(Result.Ok(file));
        }
        catch
        {
            return Task.FromResult(Result.Fail<FileStream>(new EntityNotFoundError("Image")));
        }
    }

    public Task<Result<Image>> Upload(Stream stream)
    {
        var imageId = Guid.NewGuid();
        var newName = imageId.ToString();
        using (var fStream = new FileStream(Path.Combine(_imagesPath, newName), FileMode.Create))
        {
            stream.CopyTo(fStream);
        }
        return Task.FromResult(Result.Ok(new Image(imageId)));
    }

    public bool ValidateImage(Guid imageId)
    {
        return File.Exists(Path.Combine(_imagesPath, imageId.ToString()));
    }
}