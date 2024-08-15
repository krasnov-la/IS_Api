using System.Security.Claims;

namespace Application.Commands;

public record NewActivityCommand(
    ClaimsPrincipal User,
    string Name,
    DateTime StartimgDate,
    DateTime EndingDate,
    string Preview,
    string Link);