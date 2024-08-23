using System.Security.Claims;

namespace Application.Commands.Requests;

public record ApproveRequestCommand(
    ClaimsPrincipal User,
    Guid RequestId,
    float Score);