using Application.Errors;
using Application.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class UserRepository(DbContext db) : RepositoryBase(db), IUserRepository
{
    private readonly DbSet<User> _users = db.Set<User>();
    public async Task<Result> Create(User user)
    {
        _users.Add(user);
        return await Save();
    }

    public async Task<Result<User>> GetByEmail(string email)
    {
        var user = await _users.FirstOrDefaultAsync(user => user.EmailAddress == email);
        if (user is null) return Result.Fail(new UserNotFoundError());
        return Result.Ok(user);
    }

    public async Task<Result> Update(User user)
    {
        _users.Update(user);
        return await Save();
    }
}