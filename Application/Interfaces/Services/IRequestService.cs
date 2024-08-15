using System.Security.Claims;
using Application.Commands;
using Application.DTO;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces.Services;

public interface IRequestService
{
    Task<Result> Approve(ApproveRequestCommand command);
    Task<Result<RequestDto>> Create(CreateRequestCommand command);
    Task<Result> DeleteById(Guid id);
    Task<Result<RequestDto>> GetById(Guid id);
    Task<Result<List<RequestDto>>> GetByEmail(GetRequestsByEmailCommand command);
    Task<Result<List<RequestDto>>> GetSelf(GetSelfRequestsCommand command);
    Task<Result<List<RequestDto>>> GetUnscored(int count);
    Task<Result> Reject(RejectRequestCommand command);
    Task<Result> Revoke(Guid requestId);
}