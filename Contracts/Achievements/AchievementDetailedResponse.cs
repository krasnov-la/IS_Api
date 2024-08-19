namespace Contracts.Achievements;

public record AchievementDetailedResponse(
    Guid Id,
    float Score,
    string VerificatedByAdmin
);