using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using WebApi.AuthServices;
using WebApi.AuthServices.Models;

namespace WebApi.RefreshToken
{
    public class RefreshJWTTokenIfValid : Controller
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public RefreshJWTTokenIfValid(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public IActionResult RefreshTokenIfValid(TokenValidationBody refreshToken)
        {
            try
            {
                var Principle = FromJWTToken.Instance.ValidateAndGetClaims(refreshToken.Token);//check validity of the JWT token and retrieve claims

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
                    string token = "";

                    TimeSpan ts = DateTime.Now - expiryDate;
                    BlackListToken(refreshToken.Token);
                    if (ts.TotalDays <= 6)
                    {
                        token = jwtAuthenticationManager.GenerateTokenIfValid(username, password,true);
                        new GenerateRefreshToken(username);
                    }
                    else
                    {
                        LogoutServices.Instance.Logout(username, refreshToken.Token);
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
        private void BlackListToken( string token)
        {
            using (MySqlConnection conn = new MySqlConnection(DBCreds.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "insert into BlackListTokens(token,entrytime) values('" + token + "',now());";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                }
                catch (Exception)
                {
                }
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
                throw new Exception(message: "no value");
            }
        }
    }
}
