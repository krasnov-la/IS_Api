using System.Security.Claims;

namespace Application.Commands;

public record RejectRequestCommand(
    ClaimsPrincipal User,
    Guid RequestId,
    string Message);