using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessAccessLayer.BAL
{
    public sealed class JWTService(IConfiguration configuration)
    {
        public string GenerateToken(string username)
        {
            string secretKey = configuration["JwtConfig:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("username", username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
                Issuer = configuration["JwtConfig:Issuer"],
                Audience = configuration["JwtConfig:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);


            // Implement token generation logic here using the configuration
            // For example, you can use JWT libraries to create a token with claims and signing credentials
            return token; // Placeholder for the generated token
        }
    }
}
