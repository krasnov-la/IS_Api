namespace Contracts.Comments;
public record CommentShortResponse(
    DateTime CommentingDateTime,
    string CommentText,
    Guid RequestId
);