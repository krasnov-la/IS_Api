using Domain.Enums;

namespace Application.Commands;

public record GetRequestsByEmailCommand(
    string Email,
    int Count,
    RequestStatus? Status = null);