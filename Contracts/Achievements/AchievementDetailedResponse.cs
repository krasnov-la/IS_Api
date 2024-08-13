namespace Contracts.Achievements;

public record AchievementDetailedResponse(
    Guid Id,
    float Score,
    Guid RequestId,
    DateTime VerificationDateTime,
    string VerificatedByAdmin
);