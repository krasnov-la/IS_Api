namespace Contracts.VerificationRequests;

public record VerificationRequestRequest(
    string EventName,
    string Description,
    IEnumerable<Guid> ImageIds
);