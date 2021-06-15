using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using WebApi.DatabaseModel;

namespace WebApi
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        //changing comment across systems
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
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
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Login(string username, string password)
        {
            DatabaseLoginServices databaseLoginService = new DatabaseLoginServices();
            if(!databaseLoginService.LoginMatchCreds(username,password))
            {
                return null;
            }
            return GenerateJWTToken(username,password);
        }


    }
}
