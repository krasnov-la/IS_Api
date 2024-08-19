namespace Application.DTO;

public record CommentDto(
    Guid Id,
    string CommentText,
    string CommentedByAdmin
);