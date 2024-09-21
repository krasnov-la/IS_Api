namespace Contracts.Ratings;

public record GlobalRatingResponse(
    int Place,
    string Nickname,
    string EmailAddress,
    string AvatarImgLink,
    float Score
);