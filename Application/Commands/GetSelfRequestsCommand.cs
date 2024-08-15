using System.Security.Claims;
using Domain.Enums;

namespace Application.Commands;

public record GetSelfRequestsCommand(
    ClaimsPrincipal User,
    int Count,
    RequestStatus? RequestStatus = null);