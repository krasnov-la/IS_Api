namespace Contracts.Activities;

public record ActivityRequest(
    string Name,
    DateTime StartingDate,
    DateTime EndingDate,
    string Preview,
    string Link
);