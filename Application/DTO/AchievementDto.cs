namespace Application.DTO;

public record AchievementDto(
    Guid Id,
    float Score,
    string VerificatedByAdmin
);