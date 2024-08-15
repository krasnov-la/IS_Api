using System.Security.Claims;
using Application.Commands;
using Application.DTO;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IActivityService
{
    Task<Result<ActivityDto>> Create(NewActivityCommand command);
    Task<Result> Delete(Guid id);
    Task<Result<List<ActivityDto>>> GetActive();
    Task<Result<ActivityDto>> GetById(Guid id);
}