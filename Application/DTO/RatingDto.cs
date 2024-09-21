namespace Application.DTO;

public record RatingDto(
    int Place,
    string Nickname,
    string EmailAddress,
    string AvatarImgLink,
    float Score
);