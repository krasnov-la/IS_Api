using Application.Interfaces.Infrastructure;
using Domain.Entities;

namespace Infrastructure.Common;

public class TokenIssuer : ITokenIssuer
{
    public string IssueToken(User user)
    {
        throw new NotImplementedException();
    }
}