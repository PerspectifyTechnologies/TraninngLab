using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApi.AuthServices.Authentication
{
    public class JwtAuthenticationManager
    {
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string GenerateTokenIfValid(string username, string password, bool refresh)
        {
            LoginServices databaseLoginService = new LoginServices();
            if (!databaseLoginService.MatchLoginCreds(username, password, refresh))
            {
                return null;
            }
            return GenerateJWTToken(username, password);
        }
        public string GenerateJWTToken(string username, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username),
                    new Claim("USERSECRET", password)
                }),
                Expires = DateTime.Now.AddSeconds(20),//CONFIGURE TO MINUTES OR HOURS JWT TOKEN EXPIRY
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
