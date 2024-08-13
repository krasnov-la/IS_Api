namespace Contracts.Achievements;
public record AchievementRequest(
    Guid RequestId,
    float Score
);