using System.Security.Claims;
using Domain.Enums;

namespace Application.Commands.Requests;

public record GetSelfRequestsCommand(
    ClaimsPrincipal User,
    int Count,
    int Offset,
    RequestStatus? RequestStatus = null);