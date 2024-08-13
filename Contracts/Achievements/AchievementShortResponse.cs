namespace Contracts.Achievements;

public record AchievementShortResponse(
    float Score,
    Guid RequestId,
    DateTime VerificationDateTime
);