namespace Application.DTO;
public record ActivityDto(
    Guid Id,
    string Name,
    DateTime StartingDate,
    DateTime EndingDate,
    string Preview,
    string Link,
    string CreatedByAdmin
);