using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class UserNotAuthorizedError() 
    : ErrorBase(StatusCodes.Status401Unauthorized, "You are not authorized for this action");