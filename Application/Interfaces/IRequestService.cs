using System.Security.Claims;
using Application.DTO;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces;

public interface IRequestService
{
    Task<Result> Approve(ClaimsPrincipal user, Guid reqrequestId, float score);
    Task<Result<RequestDto>> Create(ClaimsPrincipal user, string eventName, string description, IEnumerable<Guid> imageIds);
    Task<Result> DeleteById(Guid id);
    Task<Result<RequestDto>> GetById(Guid id);
    Task<Result<List<RequestDto>>> GetByLogin(string login, int count);
    Task<Result<List<RequestDto>>> GetByLogin(string login, RequestStatus status, int count);
    Task<Result<List<RequestDto>>> GetSelf(ClaimsPrincipal user, int count);
    Task<Result<List<RequestDto>>> GetSelf(ClaimsPrincipal user, RequestStatus requestStatus, int count);
    Task<Result<List<RequestDto>>> GetUnscored(int count);
    Task<Result> Reject(ClaimsPrincipal user, Guid requestId, string message);
    Task<Result> Revoke(Guid requestId);
}