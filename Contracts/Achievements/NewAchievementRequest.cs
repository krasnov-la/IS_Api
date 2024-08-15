namespace Contracts.Achievements;
public record NewAchievementRequest(
    Guid RequestId,
    float Score
);