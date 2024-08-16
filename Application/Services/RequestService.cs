using System.Security.Claims;
using Application.Commands.Requests;
using Application.DTO;
using Application.Interfaces.Services;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class RequestService : IRequestService
{
    public Task<Result> Approve(ApproveRequestCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RequestDto>> Create(CreateRequestCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetByEmail(GetRequestsByEmailCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<RequestDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetSelf(GetSelfRequestsCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<RequestDto>>> GetUnscored(int count)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Reject(RejectRequestCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Revoke(Guid requestId)
    {
        throw new NotImplementedException();
    }
}
