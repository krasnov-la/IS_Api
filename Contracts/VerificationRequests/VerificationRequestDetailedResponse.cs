using System.Text.Json.Serialization;
using Contracts.Achievements;
using Contracts.Comments;

namespace Contracts.VerificationRequests;

public record VerificationRequestFullResponse(
    Guid Id,
    string OwnerLogin,
    string EventName,
    string Description,
    DateTime CreationDatetime,
    string Status,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    AchievementDetailedResponse? Achievement,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    CommentFullResponse? Comment,
    IEnumerable<string> ImageIds
);