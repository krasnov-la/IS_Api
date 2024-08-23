using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;
using FluentResults;

namespace Infrastructure.Repositories;

public class RequestRepository : IRequestRepository
{
    public Task<Result> Create(Request request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Request>>> GetByEmail(string email, RequestStatus? status, int count, int offset)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Request>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Request>>> GetUnscored()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Request request)
    {
        throw new NotImplementedException();
    }
}