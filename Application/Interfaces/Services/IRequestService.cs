using System.Security.Claims;
using Application.Commands.Requests;
using Application.DTO;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IRequestService
{
    Task<Result> Approve(ApproveRequestCommand command);
    Task<Result<RequestDto>> Create(CreateRequestCommand command);
    Task<Result> DeleteById(Guid id);
    Task<Result<List<RequestDto>>> GetByEmail(GetRequestsByEmailCommand getRequestsByEmailCommand);
    Task<Result<RequestDto>> GetById(ClaimsPrincipal user, Guid id);
    Task<Result<List<RequestDto>>> GetSelf(GetSelfRequestsCommand getSelfRequestsCommand);
    Task<Result<List<RequestDto>>> GetUnscored(GetUnscoredCommand getUnscoredCommand);
    Task<Result> Reject(RejectRequestCommand command);
    Task<Result> Revoke(Guid requestId);
}