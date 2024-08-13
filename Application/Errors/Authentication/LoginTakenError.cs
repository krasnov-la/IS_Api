using Microsoft.AspNetCore.Http;

namespace Application.Errors.Authentication;

public class LoginTakenError(string login) 
: ErrorBase(StatusCodes.Status409Conflict, $"Login {login} already taken.");