using Microsoft.AspNetCore.Http;

namespace Application.Errors.Authentication;

public class PasswordInvalidError()
    : ErrorBase(StatusCodes.Status400BadRequest, $"Password invalid");