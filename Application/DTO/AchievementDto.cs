namespace Application.DTO;

public record AchievementDto(
    Guid Id,
    float Score,
    Guid RequestId,
    DateTime VerificationDateTime,
    string VerificatedByAdmin
);