using System.Security.Claims;

namespace Application.Commands;

public record CreateRequestCommand(
    ClaimsPrincipal User,
    string EventName,
    string Description,
    IEnumerable<Guid> ImageIds);