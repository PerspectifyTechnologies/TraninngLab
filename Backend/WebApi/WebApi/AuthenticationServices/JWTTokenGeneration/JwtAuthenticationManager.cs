using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi.DatabaseServices;

namespace WebApi
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        //changing comment across systems for git learning(later remove)
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string GenerateTokenIfValid(string username, string password, int refresh)
        {
            DatabaseLoginServices databaseLoginService = new DatabaseLoginServices();
            if (!databaseLoginService.MatchLoginCreds(username, password, refresh))
            {
                return null;//not matching USER CREDENTIALS
            }
            return GenerateJWTToken(username, password, refresh);
        }
        public string GenerateJWTToken(string username, string password,int refresh)
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
                Expires = DateTime.Now.AddSeconds(20),//In seconds CONFIGURE TO MINUTES OR HOURS
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
