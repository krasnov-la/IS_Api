namespace Contracts.Activities;

public record NewActivityRequest(
    string Name,
    DateTime StartingDate,
    DateTime EndingDate,
    string Preview,
    string Link
);