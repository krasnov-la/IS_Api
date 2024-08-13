namespace Contracts.Comments;
public record CommentFullResponse(
    Guid Id,
    DateTime CommentingDateTime,
    string CommentText,
    Guid RequestId,
    string CommentedByAdmin
);