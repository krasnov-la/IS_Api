namespace Contracts.VerificationRequests;

public record NewVerificationRequestRequest(
    string EventName,
    string Description,
    IEnumerable<Guid> ImageIds
);