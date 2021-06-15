using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebApi.DatabaseModel;
using WebApi.RefreshTokenGeneration;

namespace WebApi.Controllers
{
    public class RefreshJWTTokenIfValid : Controller
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public RefreshJWTTokenIfValid(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public IActionResult RefreshTokenIfValid(TokenValidationBody refreshToken)
        {
            try
            {
                FromJWTToken fromJWTToken = new FromJWTToken();
                var Principle = fromJWTToken.ValidateAndGetClaims(refreshToken.Token);
                if (Principle != null)
                {
                    var username = Principle.Identity.Name;
                    var password = Principle.Claims.FirstOrDefault(x => x.Type.ToString().Equals("USERSECRET", StringComparison.InvariantCultureIgnoreCase)).Value;

                    RefreshTokenInDB refreshTokenInDB = new RefreshTokenInDB();
                    DateFormat dateFormat= new DateFormat();

                    Tuple<string, string> Refreshtoken = refreshTokenInDB.Check(username);
                    DateTime expiryDate = dateFormat.ConvertToSTDDateTime(Refreshtoken.Item2);

                    string token = "";

                    if (Refreshtoken is null)
                    {
                        throw new Exception(message: "No Refresh Token for The User");
                    }

                    TimeSpan ts = DateTime.UtcNow - expiryDate;
                    if (ts.TotalHours <= 6)
                    {
                        token = jwtAuthenticationManager.Login(username, password);
                        new GenerateRefreshToken(username);
                    }
                    return Ok(new { Status = "Success", passwordsa = password, adasdasd = token });

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return Unauthorized(new { Status = "Error", Message = e.Message });
            }
        }
    }
}
