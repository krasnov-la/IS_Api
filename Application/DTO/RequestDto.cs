using System.Text.Json.Serialization;

namespace Application.DTO;
public record RequestDto(
    Guid Id,
    string OwnerLogin,
    string EventName,
    string Description,
    DateTime CreationDatetime,
    string Status,
    AchievementDto? Achievement,
    CommentDto? Comment,
    IEnumerable<string> ImageIds
);