namespace Contracts.Ratings;

public record GlobalRatingResponse(
    int Place,
    string Nickname,
    string EmailAddress,
    float Score
);