using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class UserDontExistError(string login)
    : ErrorBase(StatusCodes.Status404NotFound, $"User with login \"{login}\" dont exist");