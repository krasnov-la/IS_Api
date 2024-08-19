namespace Contracts.Comments;
public record CommentFullResponse(
    Guid Id,
    string CommentText,
    string CommentedByAdmin
);