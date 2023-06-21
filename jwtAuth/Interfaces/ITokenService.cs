using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using jwtAuth.Model;

namespace jwtAuth.Interfaces
{
    public interface ITokenService
    {
        String CreateToken(UserDto user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(String token);
        String CreateTokenFromClaims(List<Claim> authClaims);
    }
}