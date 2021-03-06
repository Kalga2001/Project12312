using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Common.Interfaces.Repositories;
using OnlineShop.Infrastructure.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineShop.Infrastructure.Identity
{
    public class TokenService : ITokenService
    {
        private readonly AuthOptions _authenticationOptions;

        public TokenService(IOptions<AuthOptions> authenticationOptions)
        {
            _authenticationOptions = authenticationOptions.Value;
        }

        public string GenerateAccessToken()
        {
            var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: _authenticationOptions.Issuer,
                 audience: _authenticationOptions.Audience,
                 claims: new List<Claim>(),
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
            return encodedToken;
        }
    }
}
