using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using WebApi.AuthServices;
using WebApi.AuthServices.Models;

namespace WebApi.RefreshToken
{
    public class RefreshJWTToken : Controller
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public RefreshJWTToken(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public IActionResult RefreshTokenIfValid(string token)
        {
            try
            {
                var Principle = FromJWTToken.Instance.ValidateAndGetClaims(token);//check validity of the JWT token and retrieve claims

                if (Principle != null)
                {
                    var username = Principle.Identity.Name;
                    var password = Principle.Claims.FirstOrDefault(x =>
                        x.Type.ToString().Equals(
                        "USERSECRET", StringComparison.InvariantCultureIgnoreCase))
                        .Value;
                    Tuple<string, string> Refreshtoken = RefreshTokenInDB.Instance.Check(username);
                    if (Refreshtoken is null)
                        throw new Exception(message: "No Refresh Token for The User");
                    DateTime expiryDate = ConvertToSTDDateTime(Refreshtoken.Item2);
                    string newToken = "";

                    TimeSpan ts = DateTime.Now - expiryDate;
                    if (ts.TotalDays <= 6)
                    {
                        newToken = jwtAuthenticationManager.GenerateTokenIfValid(username, password,true);
                        new GenerateRefreshToken(username);
                    }
                    else
                    {
                        LogoutServices.Instance.Logout(username, token);
                        return Unauthorized( new { Status = "error",
                                                   Username = username,
                                                   JwtToken = "" });
                    }
                    return Ok(new { Status = "Success",
                        Username = username,
                        JwtToken = token });

                }
                else
                {
                    return Unauthorized(new { Status = "Error", 
                                              JwtToken = ""});
                }
            }
            catch (Exception)
            {
                return Unauthorized(new { Status = "Error",
                                          JwtToken = "" });
            }
        }

        private DateTime ConvertToSTDDateTime(string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
                throw new Exception(message: "error at ConvertToSTDDateTime(string value)");
            }
        }
    }
}
