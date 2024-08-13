namespace Infrastructure.Options.Authentication;

public class PolicyOptions
{
    public required string AdminOnlyPolicyName {get; init;}
    public required string AdminClaimName {get; init;}
}