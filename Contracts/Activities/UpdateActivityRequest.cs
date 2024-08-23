namespace Contracts.Activities;

public record UpdateActivityRequest(
    string? Name,
    DateTime? StartingDate,
    DateTime? EndingDate,
    string? Preview,
    string? Link
);