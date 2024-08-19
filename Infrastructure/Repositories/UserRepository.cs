using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<Result> Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(User user)
    {
        throw new NotImplementedException();
    }
}