using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ErpaHolding.API.Tools
{
    public static class TokenGenerator
    {
        //identity web api jwt
        public static string GenerateToken(Guid userId, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("userId", userId.ToString()));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            }
         

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("enesBakiEnes!?_.!*EnesBakiEnes"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken? securityToken = new JwtSecurityToken(
                issuer: "ABCDEF", 
                audience: "http://localhost:7264", 
                claims: claims, 
                expires: DateTime.Now.AddMinutes(5), 
                signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(securityToken);
        }
    }
}
