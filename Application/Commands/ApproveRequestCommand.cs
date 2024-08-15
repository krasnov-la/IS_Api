using System.Security.Claims;

namespace Application.Commands;

public record ApproveRequestCommand(
    ClaimsPrincipal User,
    Guid ReqrequestId,
    float Score);