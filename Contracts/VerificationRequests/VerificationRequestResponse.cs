namespace Contracts.VerificationRequests;

public record VerificationRequestResponse(
    Guid Id,
    string OwnerLogin,
    string EventName,
    DateTime CreationDatetime,
    string Status
);