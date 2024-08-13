using Application.DTO;
using Application.Interfaces;
using Contracts.Images;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("images")]
public class ImagesController(IImageService imageService) : ApiController
{
    private readonly IImageService _imageService = imageService;

    [HttpPost]
    //[Authorize]
    [Produces(typeof(ImageResponse))]
    public async Task<IActionResult> PostNewImage([FromForm] IFormFile file)
    {
        Result<ImageDto> result = await _imageService.Upload(file.OpenReadStream());
        return ResultToResponse(result, v => new ImageResponse(v.Id));
    }

    [HttpGet("{id}")]
    //[Authorize]
    public async Task<IActionResult> GetImage(Guid id)
    {
        Result<FileStream> result = await _imageService.GetImage(id);
        return ResultToResponse(result, v => v);
    }

    //TODO: Завести воркера для удаления неиспользуемых картинок
}