using Domain.Entities;

namespace Application.Interfaces.Infrastructure;

public interface ITokenIssuer
{
    string IssueToken(User user);
}