using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class UserNotAuthenticatedError() : ErrorBase(StatusCodes.Status403Forbidden, "You are not authenticated");