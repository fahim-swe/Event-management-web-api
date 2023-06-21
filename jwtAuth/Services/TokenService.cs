using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using jwtAuth.Interfaces;
using jwtAuth.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace jwtAuth.Services
{
    public class TokenService : ITokenService
    {
         private readonly SymmetricSecurityKey _key;
        public readonly IOptions<TokenSetting> _tokenSetting;

        public TokenService(IOptions<TokenSetting> tokenSetting)
        {
            _tokenSetting = tokenSetting;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSetting.Value.Secret));
        }

        public string CreateToken(UserDto user)
        {
            var authClaims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Name", user.Name),
                new Claim("Id", user.Id.ToString()),
            };

            return CreateTokenFromClaims(authClaims);
        }

        public string CreateTokenFromClaims(List<Claim> authClaims)
        {
            _ = int.TryParse(_tokenSetting.Value.TokenValidityInMinutes, out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer : _tokenSetting.Value.ValidIssuer,
                audience: _tokenSetting.Value.ValidAudience,
                expires : DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims : authClaims,
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
            );
            _ = int.TryParse(_tokenSetting.Value.RefreshTokenValidityInDays, out int refreshTokenValidityInDays);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            
            throw new NotImplementedException();
        }
    }
}