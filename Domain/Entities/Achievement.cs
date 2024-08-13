namespace Domain.Entities;

public record Achievement
{
    public Guid Id { get; init; }
    public Admin Admin { get; init; }
    public float Score { get; init; }

    public Achievement(Admin admin, float score)
    {
        Id = Guid.NewGuid();
        Admin = admin;
        Score = score;
    }
}