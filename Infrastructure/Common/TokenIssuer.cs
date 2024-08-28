using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces.Infrastructure;
using Domain.Entities;
using Infrastructure.Options.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Common;

public class TokenIssuer(IOptions<JwtOptions> iOptions) : ITokenIssuer
{
    private readonly JwtOptions _options = iOptions.Value;
    public string IssueToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        List<Claim> claims = [
            new (ClaimTypes.Role, user.Role.ToString()),
            new (ClaimTypes.Email, user.EmailAddress)
        ];
        var tokenData = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(tokenData);
    }
}