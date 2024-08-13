using System.Security.Claims;
using Application.DTO;
using FluentResults;

namespace Application.Interfaces;

public interface IActivityService
{
    Task<Result<ActivityDto>> Create(ClaimsPrincipal user, string name, DateTime startimgDate, DateTime endingDate, string Preview, string Link);
    Task<Result> Delete(Guid id);
    Task<Result<List<ActivityDto>>> GetActive();
    Task<Result<ActivityDto>> GetById(Guid id);
}