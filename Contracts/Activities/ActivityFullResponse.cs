namespace Contracts.Activities;

public record ActivityFullResponse(
    Guid Id,
    string Name,
    DateTime StartingDate,
    DateTime EndingDate,
    string Preview,
    string Link,
    string CreatedByAdmin
);