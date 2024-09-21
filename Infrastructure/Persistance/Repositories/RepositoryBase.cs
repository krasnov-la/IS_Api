using Application.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class RepositoryBase(DbContext db)
{
    private readonly DbContext _db = db;

    public async Task<Result> Save()
    {
        try
        {
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {
            //TODO Logging
            return Result.Fail(new UnexpectedError());
        }
        return Result.Ok();
    } 
}