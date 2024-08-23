using Domain.Entities;
using Domain.Enums;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IRequestRepository
{
     Task<Result> Create(Request request);
     Task<Result> DeleteById(Guid id);
     Task<Result<List<Request>>> GetByEmail(string email, RequestStatus? status, int count, int offset);
     Task<Result<Request>> GetById(Guid id);
     Task<Result<List<Request>>> GetUnscored();
     Task<Result> Update(Request request);
}