namespace Contracts.Ratings;

public record RatingResponse(
    int Place,
    string Nickname,
    string EmailAddress,
    float Score
);