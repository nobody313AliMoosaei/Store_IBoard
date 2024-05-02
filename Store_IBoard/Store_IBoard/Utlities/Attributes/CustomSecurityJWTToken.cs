using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store_IBoard.Utlities.Attributes
{
    public class CustomSecurityJWTToken:JwtSecurityTokenHandler
    {
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            var jwtTokenString = Encoding.UTF8.GetString(Convert.FromBase64String(token.Replace("Bearer ","").ToString()));
            return base.ValidateToken(jwtTokenString, validationParameters, out validatedToken);
        }
    }
}
