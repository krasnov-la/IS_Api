namespace Application.DTO;

public record RatingDto(
    int Place,
    string Nickname,
    string EmailAddress,
    float Score
);