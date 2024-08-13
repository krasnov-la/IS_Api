namespace Application.DTO;

public record CommentDto(
    Guid Id,
    Guid RequestId,
    DateTime CommentingDateTime,
    string CommentText,
    string CommentedByAdmin
);