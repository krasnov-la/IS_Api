using Domain.Enums;

namespace Application.Commands.Requests;

public record GetRequestsByEmailCommand(
    string Email,
    int Count,
    int Offset,
    RequestStatus? Status = null);