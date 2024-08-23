using Domain.Entities;
using FluentResults;

namespace Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<Result<User>> GetByEmail(string email);
    Task<Result> Update(User user);
    Task<Result> Create(User user);
}