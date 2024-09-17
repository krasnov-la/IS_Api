using System.Text.Json.Serialization;
using Contracts.Achievements;
using Contracts.Comments;

namespace Contracts.VerificationRequests;

public record VerificationRequestResponse(
    Guid Id,
    string OwnerLogin,
    string EventName,
    DateTime CreationDatetime,
    string Status,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    AchievementShortResponse? Achievement,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    CommentShortResponse? Comment
);