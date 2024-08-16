using System.Security.Claims;

namespace Application.Commands.Requests;

public record RejectRequestCommand(
    ClaimsPrincipal User,
    Guid RequestId,
    string Message);