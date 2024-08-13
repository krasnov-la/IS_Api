namespace Contracts.Activities;

public record ActivityShortResponse(
    string Name,
    DateTime StartingDate,
    DateTime EndingDate,
    string Preview,
    string Link
);